using Entity.Entity;
using HotelClient.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelClient.ViewModel
{
    public class RoomViewModel : EntityViewModel<Room>
    {
        public RoomViewModel()
            : base(new Room())
        {
            hotelsService = new EntitiesService<Hotel>();
            _updateEntityList(null);
        }
        public RoomViewModel(Room room)
            : base(room)
        {
            hotelsService = new EntitiesService<Hotel>();
            _updateEntityList(null);           
            if (room != null)
            {
                SelectedItem = room.HotelOwner;
            }
            
        }
        public ObservableCollection<Hotel> Hotels { get; set; }

        private EntitiesService<Hotel> hotelsService;
        public Hotel SelectedItem { get; set; }
        public override void createEntity(object obj)
        {
            EntitiesService<Room> model = new EntitiesService<Room>();
            Entity.HotelOwner = SelectedItem;
            model.AddEntity(Entity, "api/room");
        }
        public override void updateEntity(object obj)
        {
            EntitiesService<Room> model = new EntitiesService<Room>();
            Entity.HotelOwner = SelectedItem;
            model.UpdateEntity(Entity, "api/room" + "/" + Entity.Id);
        }

        public override bool canExecuteCreate()
        {
            return true;
        }
        public override bool canExecuteUpdate()
        {
            return true;
        }
        private void _updateEntityList(object obj)
        {
            if (Hotels == null)
            {
                Hotels = new ObservableCollection<Hotel>();
            }
            Hotels.Clear();
            var rawEntities = new ObservableCollection<Hotel>(hotelsService.GetAllEntities("api/hotel"));
            foreach (Hotel rawEntity in rawEntities)
            {
                Hotels.Add(rawEntity);
            }
        }
    }
}
