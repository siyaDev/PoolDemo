using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace MongoDBPool.ViewModels
{
    public class  PlayerCreateViewModel
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]       
        public IEnumerable<SelectListItem> SelectedPLayerValue { get; set; }
        [Required]
        public IEnumerable<SelectListItem> BalckBallPLayerValue { get; set; }             
        [Required]
        public string EmailAddress { get; set; }


    }
}
