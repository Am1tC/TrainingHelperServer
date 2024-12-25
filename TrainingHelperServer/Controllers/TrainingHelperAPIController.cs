﻿using TrainingHelperServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using TrainingHelperServer.DTO;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace TrainingHelperServer.Controllers;

[Route("api")]
[ApiController]
public class TrainingHelperAPIController : ControllerBase
{
    //a variable to hold a reference to the db context!
    private TrainingHelperDbContext context;
    //a variable that hold a reference to web hosting interface (that provide information like the folder on which the server runs etc...)
    private IWebHostEnvironment webHostEnvironment;
    //Use dependency injection to get the db context and web host into the constructor
    public TrainingHelperAPIController(TrainingHelperDbContext context, IWebHostEnvironment env)
    {
        this.context = context;
        this.webHostEnvironment = env;
    }

    [HttpGet]
    [Route("TestServer")]
    public ActionResult<string> TestServer()
    {
        return Ok("Server Responded Successfully");
    }
    [HttpPost("login")]
    public IActionResult LoginTrainee([FromBody] DTO.LoginInfo loginDto)
    {
        try
        {
            HttpContext.Session.Clear(); //Logout any previous login attempt

            //Get model user class from DB with matching email. 
            Models.Trainee? trainee = context.GetTrainee(loginDto.Id);

            //Check if user exist for this email and if password match, if not return Access Denied (Error 403) 
            if (trainee == null || trainee.Password != loginDto.Password)
            {
                return Unauthorized();
            }

            //Login suceed! now mark login in session memory!
            HttpContext.Session.SetString("loggedInUser", trainee.TraineeId.ToString());

            DTO.Trainee dtotrainee = new DTO.Trainee(trainee);
            //dtoUser.ProfileImagePath = GetProfileImageVirtualPath(dtoUser.Id);
            return Ok(dtotrainee);

           
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }


    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] DTO.Trainee userDto)
    {
        try
        {
            HttpContext.Session.Clear(); //Logout any previous login attempt

            userDto.SubscriptionStartDate = DateTime.Now;
            userDto.SubscriptionEndDate = DateTime.Now.AddYears(1);
            userDto.BirthDate = DateTime.Now;
            //Create model user class
            Models.Trainee modelsUser = userDto.GetModel();

            context.Trainees.Add(modelsUser);
            context.SaveChanges();

            //User was added!
            DTO.Trainee dtoUser = new DTO.Trainee(modelsUser);
            //dtoUser.pro = GetProfileImageVirtualPath(dtoUser.Id);
            return Ok(dtoUser);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

    // update profile imp

    [HttpGet("showTrainings")]
    //public List<DTO.Training> ShowTrainings([FromBody] DateTime date)
    //{
    //    try
    //    {

         
    //        List<Training> modelsTraining = context.GetTrainings(date);

           
    //        return modelsTraining;
    //    }
    //    catch (Exception ex)
    //    {
            
    //        return new List<Training>(); // Return an empty list as fallback
    //    }

    //}

    [HttpGet("GetTrainings")]
    public IActionResult GetTrainings()
    {
        try
        {
            //Check if who is logged in
            string? userEmail = HttpContext.Session.GetString("loggedInUser");
            if (string.IsNullOrEmpty(userEmail))
            {
                return Unauthorized("User is not logged in");
            }

            //Read posts of the user

            List<Models.Training> list = context.GetTrainings();

            List<DTO.Training> trainings = new List<DTO.Training>();

            foreach (Models.Training t in list)
            {
                DTO.Training training = new DTO.Training(t);
                
                trainings.Add(training);
            }
            return Ok(trainings);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

    [HttpPost("SignUpForTraining")]
    public IActionResult SignUpForTraining(int trainingNumber)
    {
        try
        {
            // Check if the user is logged in
            string? userEmail = HttpContext.Session.GetString("loggedInUser");
            if (string.IsNullOrEmpty(userEmail))
            {
                return Unauthorized("User is not logged in");
            }

            // Retrieve the training session for the given training number
            var training = context.GetTraining(DateTime.Now).FirstOrDefault(t => t.TrainingNumber == trainingNumber); // Filter by today's date or use any specific date you prefer

            if (training == null)
            {
                return NotFound("Training not found.");
            }

            // Retrieve the trainee using the logged-in user's email
            var trainee = context.Trainees.FirstOrDefault(t => t.Email == userEmail);

            if (trainee == null)
            {
                return BadRequest("Trainee not found.");
            }

            // Check if the trainee is already signed up for this training
            var existingSignUp = context.TraineesInPractices
                .FirstOrDefault(tp => tp.TraineeId == trainee.TraineeId && tp.TrainingNumber == trainingNumber);

            if (existingSignUp != null)
            {
                return BadRequest("You are already signed up for this training.");
            }

            // Add the trainee to the training
            context.TraineesInPractices.Add(new Models.TraineesInPractice
            {
                TraineeId = trainee.TraineeId,
                TrainingNumber = trainingNumber,
                HasArrived = false // Initial status
            });

            context.SaveChanges(); // Commit changes to the database

            return Ok("Successfully signed up for the training.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}








