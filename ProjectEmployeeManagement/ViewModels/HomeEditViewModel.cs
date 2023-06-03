using System.ComponentModel.DataAnnotations;

namespace ProjectEmployeeManagement.ViewModels
    {
    public class HomeEditViewModel:HomeCreateViewModel
        {
        public int Id { get; set; } 
        public string? ExistingPhotoPath { get; set; }
        }
    }
