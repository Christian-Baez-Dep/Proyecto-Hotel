using System;
using Entidades.Modelo;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;


public class DaoRoom
{
	
    private readonly ApplicationContext context;

    public DaoRoom(ApplicationContext context)
    {
        this.context = context;
    }

    public List<Room> GetRoom()
    {
        var availableRooms = this.context.Rooms.Where(mp => mp.isAvailable).ToList();

        return availableRooms;
    }
    public Room GetRoomId (int roomId)
    {
        return this.context.Rooms.FirstOrDefault(mp => mp.Id == roomId);
    }
    
    public void  DeleteRoom (Room room )
    {
        var roomToDelete = this.context.Rooms.FirstOrDefault(mp => mp.Id == room.Id);

        try
        {
           if (roomToDelete != null)
           {
                var reservationToDelete = this.context.Reservations.Where(mp => mp.IdRoom == room.Id);
                this.context.Reservations.RemoveRange(reservationToDelete);

                this.context.Rooms.Remove(roomToDelete);
                this.context.SaveChanges();
           }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
               
    }
    public void SaveRoom (Room room)
    {
        try
        {
            this.context.Rooms.Add(room);
            this.context.SaveChanges();

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);

        }
        
    }
    public void UpdateRoom (Room room)
    {
        try
        {
            Room roomUpdate = this.context.Rooms.Find(room.Id);
            if (roomUpdate != null)
            {
                roomUpdate.CodeRoom = room.CodeRoom;
                roomUpdate.Price = room.Price;
                roomUpdate.isAvailable = room.isAvailable;
            }

            this.context.Rooms.Update(roomUpdate);
            this.context.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
              
    }
}
