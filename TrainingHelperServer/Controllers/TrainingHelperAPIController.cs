﻿using TrainingHelperServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using TrainingHelperServer.DTO;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
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

    #region Login
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
            HttpContext.Session.SetString("loggedInUser", trainee.Id.ToString());

            DTO.Trainee dtotrainee = new DTO.Trainee(trainee);
            //dtoUser.ProfileImagePath = GetProfileImageVirtualPath(dtoUser.Id);
            return Ok(dtotrainee);


        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("trainerlogin")]
    public IActionResult TrainerLogin([FromBody] DTO.LoginInfo loginDto)
    {
        try
        {
            HttpContext.Session.Clear(); //Logout any previous login attempt

            //Get model user class from DB with matching email. 
            Models.Trainer? trainer = context.GetTrainer(loginDto.Id);

            //Check if user exist for this email and if password match, if not return Access Denied (Error 403) 
            if (trainer == null || trainer.Password != loginDto.Password)
            {
                return Unauthorized();
            }

            //Login suceed! now mark login in session memory!
            HttpContext.Session.SetString("loggedInUser", trainer.Id.ToString());

            DTO.Trainer dtotrainer = new DTO.Trainer(trainer);
            //dtoUser.ProfileImagePath = GetProfileImageVirtualPath(dtoUser.Id);
            return Ok(dtotrainer);

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


    [HttpPost("ownerlogin")]
    public IActionResult OwnerLogin([FromBody] DTO.LoginInfo loginDto)
    {
        try
        {
            HttpContext.Session.Clear(); //Logout any previous login attempt

            //Get model user class from DB with matching email. 
            Models.Owner? owner = context.GetOwner(loginDto.Id);

            //Check if user exist for this email and if password match, if not return Access Denied (Error 403) 
            if (owner == null || owner.Password != loginDto.Password)
            {
                return Unauthorized();
            }

            //Login suceed! now mark login in session memory!
            HttpContext.Session.SetString("loggedInUser", owner.OwnerId.ToString());

            DTO.Owner dtoOwner = new DTO.Owner(owner);
            //dtoUser.ProfileImagePath = GetProfileImageVirtualPath(dtoUser.Id);
            return Ok(dtoOwner);


        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }


    }
    #endregion

    #region Register

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


    [HttpPost("registertrainer")]
    public IActionResult RegisterTrainer([FromBody] DTO.Trainer userDto)
    {
        try
        {
            HttpContext.Session.Clear(); //Logout any previous login attempt

         
            userDto.BirthDate = DateOnly.FromDateTime(DateTime.Now);
            //Create model user class
            Models.Trainer modelsUser = userDto.GetModel();

            context.Trainers.Add(modelsUser);
            context.SaveChanges(); // id is unique 
            //User was added!
            DTO.Trainer dtoUser = new DTO.Trainer(modelsUser);
            //dtoUser.pro = GetProfileImageVirtualPath(dtoUser.Id);
            return Ok(dtoUser);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }
    #endregion


    //update profile imp
    [HttpPost("updateUser")]
    public IActionResult UpdateUser([FromBody] DTO.Trainee userDto)
    {
        try
        {
            //Check if who is logged in
            string? userId = HttpContext.Session.GetString("loggedInUser");
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User is not logged in");
            }

            //Get model user class from DB with matching email. 
            Models.Trainee? user = context.GetTrainee(userId);
            //Clear the tracking of all objects to avoid double tracking
            context.ChangeTracker.Clear();


            if (user == null || userDto.Id != user.Id)
            {
                return Unauthorized("trying to update a different user");
            }

            Models.Trainee appUser = userDto.GetModel();

            context.Entry(appUser).State = EntityState.Modified;

            context.SaveChanges();

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }



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

    [HttpGet("GetTrainees")]
    public IActionResult GetTrainees()
    {
        try
        {
            // Check if the user is logged in
            string userId = HttpContext.Session.GetString("loggedInUser");
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User is not logged in");
            }

            List<Models.Trainee> list = context.GetAllTrainees();
            List<DTO.Trainee> trainees = new List<DTO.Trainee>();
            foreach (Models.Trainee t in list)
            {
                DTO.Trainee trainee = new DTO.Trainee(t);
                trainees.Add(trainee);
            }
            return Ok(trainees);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("DeleteTrainee")]
    public IActionResult DeleteTrainee([FromBody] string traineeNumber)
    {
        try 
        {
            string userId = HttpContext.Session.GetString("loggedInUser");
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User is not logged in");
            }
            
            DTO.Trainee trainee = new DTO.Trainee(context.GetTrainee(traineeNumber));
            if (trainee == null)
            {
                return NotFound("Trainee not found.");
            }
            Models.Trainee temp = trainee.GetModel();
            context.Trainees.Remove(temp);


            context.SaveChanges();


            //Task was updated!
            return Ok();

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }


    }

    [HttpPost("DeleteTrainer")]
    public IActionResult DeleteTrainer([FromBody] string trainerNumber)
    {
        try
        {
            string userId = HttpContext.Session.GetString("loggedInUser");
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User is not logged in");
            }

            DTO.Trainer trainer = new DTO.Trainer(context.GetTrainer(trainerNumber));
            if (trainer == null)
            {
                return NotFound("Trainer not found.");
            }
            Models.Trainer temp = trainer.GetModel();
            context.Trainers.Remove(temp);


            context.SaveChanges();


            //Task was updated!
            return Ok();

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }


    }





    [HttpGet("GetTrainers")]
    public IActionResult GetTrainers()
    {
        try
        {
            // Check if the user is logged in
            string userId = HttpContext.Session.GetString("loggedInUser");
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User is not logged in");
            }

            List<Models.Trainer> list = context.GetAllTrainers();
            List<DTO.Trainer> trainers = new List<DTO.Trainer>();
            foreach (Models.Trainer t in list)
            {
                DTO.Trainer trainer = new DTO.Trainer(t);
                trainers.Add(trainer);
            }
            return Ok(trainers);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }



    [HttpPost("OrderTraining")]
    public IActionResult OrderTraining([FromBody] int trainingNumber)
    {
        try
        {   // Check if the user is logged in
            string? userId = HttpContext.Session.GetString("loggedInUser");
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User is not logged in");
            }

            // Retrieve the training session for the given training number
            Models.Training? training = context.GetTraining(trainingNumber);
            if (training == null)
            {
                return NotFound("Training not found.");
            }
            // Retrieve the trainee using the logged-in user's id

            var trainee = context.GetTrainee(userId); //returns null for unknown reason-- fixed nvm
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

    [HttpGet("GetUserEvents")]
    public IActionResult GetUserEvents()
    {
        try
        {
            //Check if who is logged in
            string? userId = HttpContext.Session.GetString("loggedInUser");
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User is not logged in");
            }


            //Get model user class from DB with matching id. 
            Models.Trainee? user = context.GetTrainee(userId);
            List<Models.TraineesInPractice> list = context.GetOrderdTrainings(user.TraineeId.ToString());

            List<DTO.Training> trainings = new List<DTO.Training>();
          

            foreach (Models.TraineesInPractice t in list)
            {
                DTO.Training training = new DTO.Training(context.GetTraining(t.TrainingNumber));

                trainings.Add(training);
            }

            return Ok(trainings);


        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }







       [HttpPost("CreateTraining")]
    public IActionResult CreateTraining([FromBody]DTO.Training trainingDto)
    {
        try
        {
            // create model user
            // make sure trainer id is real
            var t = context.GetTrainerViaSerialNumber(trainingDto.Trainer.TrainerId); //retruns null
            if (t == null)
            {
                return BadRequest("Trainer not found");
            }
            trainingDto.Trainer = null;
            Models.Training modeltraining = trainingDto.GetModel();



            context.Training.Add(modeltraining);

            context.SaveChanges(); 
            

            trainingDto = new DTO.Training(modeltraining);

            return Ok(trainingDto);
        }
        catch (Exception ex)
        {
            return BadRequest("Error when creating training");
        }

    }

   





}









