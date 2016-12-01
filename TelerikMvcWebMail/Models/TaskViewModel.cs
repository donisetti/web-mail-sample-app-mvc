﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelerikMvcWebMail.Models
{
	public class TaskViewModel : Kendo.Mvc.UI.ISchedulerEvent
	{
		public int TaskID { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		private DateTime start;
		public DateTime Start
		{
			get
			{
				return start;
			}
			set
			{
				start = value.ToUniversalTime();
			}
		}

		public string StartTimezone { get; set; }

		private DateTime end;
		public DateTime End
		{
			get
			{
				return end;
			}
			set
			{
				end = value.ToUniversalTime();
			}
		}

		public string EndTimezone { get; set; }

		public string RecurrenceRule { get; set; }

		public int? RecurrenceID { get; set; }

		public string RecurrenceException { get; set; }

		public bool IsAllDay { get; set; }

		public int? OwnerID { get; set; }

		// The below will convert the TaskViewModel to entity Task
		//public Task ToEntity()
		//{
		//	return new Task
		//	{
		//		TaskID = TaskID,
		//		Title = Title,
		//		Start = Start,
		//		StartTimezone = StartTimezone,
		//		End = End,
		//		EndTimezone = EndTimezone,
		//		Description = Description,
		//		RecurrenceRule = RecurrenceRule,
		//		RecurrenceException = RecurrenceException,
		//		RecurrenceID = RecurrenceID,
		//		IsAllDay = IsAllDay,
		//		OwnerID = OwnerID
		//	};
		//}
	}
}