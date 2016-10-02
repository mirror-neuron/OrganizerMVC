using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using OrganizerMVC.Models;

/// <summary>
/// EventDAO class is the main class which interacts with the database. SQL Server express edition
/// has been used.
/// the event information is stored in a table named 'event' in the database.
///
/// Here is the table format:
/// event(event_id int, title varchar(100), description varchar(200),event_start datetime, event_end datetime)
/// event_id is the primary key
/// </summary>
public class EventDAO
{
    private DbEntities db = new DbEntities();

    //this method retrieves all events within range start-end
    public List<Events> getEvents(DateTime start, DateTime end)
    {        
        return db.Events.Where(x => start <= x.Start && x.End <= end).ToList();
        //side note: if you want to show events only related to particular users,
        //if user id of that user is stored in session as Session["userid"]
        //the event table also contains an extra field named 'user_id' to mark the event for that particular user
        //then you can modify the SQL as:
        //SELECT event_id, description, title, event_start, event_end FROM event where user_id=@user_id AND event_start>=@start AND event_end<=@end
        //then add paramter as:cmd.Parameters.AddWithValue("@user_id", HttpContext.Current.Session["userid"]);
    }

	//this method updates the event title and description
    public void updateEvent(int id, String title, String description)
    {
        var ce = db.Events.Find(id);
        ce.Title = title;
        ce.Description = description;
        db.SaveChanges();
    }

	//this method updates the event start and end time ... allDay parameter added for FullCalendar 2.x
    public void updateEventTime(int id, DateTime start, DateTime end, bool fullDay)
    {
        var ce = db.Events.Find(id);
        ce.Start = start;
        ce.End = end;
        ce.FullDay = fullDay;
        db.SaveChanges();
    }

	//this mehtod deletes event with the id passed in.
    public void deleteEvent(int id)
    {
        db.Events.Remove(db.Events.Find(id));
        db.SaveChanges();
    }

	//this method adds events to the database
    public int addEvent(Events ce)
    {
        db.Events.Add(ce);
        db.SaveChanges();
        return ce.Id;
    }
}
