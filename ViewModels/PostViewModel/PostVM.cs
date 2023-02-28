using Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.PostViewModel
{
	public class PostVM
	{
		//[Required]
		[Display(Name = "ID")]
		public int PostId { get; set; }

		//[Required]
		[Display(Name = "Post Title")]
		public string? PostTitle { get; set; }

		//[Required]
		[Display(Name = "Post Detail")]
		public string? PostDetails { get; set; }

		[Display(Name = "Sort Description")]
		public string? SortDesc { get; set;}

		//[Required]
		[Display(Name = "Budget")]
		public decimal? Budget { get; set; }

		//[Required]
		[Display(Name = "Expire Date")]
		public DateTime? ExpirationDate { get; set; }

		[Display(Name = "Post Date")]
		public DateTime? PostedDate { get; set; } = DateTime.Now;

		//[Required]
		[Display(Name = "Category")]
		public int? CategoryId { get; set; }

		[Display(Name = "User")]
		public Guid UserId { get; set; }

		//[Required]
		[Display(Name = "Author's Name")]
		public string? ClientName { get; set; }

		//[Required]
		[Display(Name = "Post Status")]
		public string? PostStatus { get; set; }

		//[Required]
		[Display(Name = "Is Post Public ?")]
		public bool isPostPublic { get; set; }

		//[Required]
		[Display(Name = "Require Level")]
		public string? LevelRequired { get; set; }
		public Category? Category { get; set; }
	}
}
