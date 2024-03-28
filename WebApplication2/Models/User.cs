﻿using System.Text.Json.Serialization;

namespace WebApplication2.Models
{
	public class User
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		[JsonIgnore]
		public ICollection<Vehicles>? Vehicles { get; set; }
	}
}