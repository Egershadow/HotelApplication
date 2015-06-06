using Entity;
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
    public class HotelJournalViewModel : EntityViewModel<HotelJournal>
    {
        public HotelJournalViewModel()
            : base(new HotelJournal())
        {
            _updateRoomsList(null);
            _updateGuestsList(null);
        }
        public HotelJournalViewModel(HotelJournal hotelJournal)
            : base(hotelJournal)
        {
            _updateRoomsList(null);
            _updateGuestsList(null);
            if (hotelJournal != null)
            {
                SelectedGuest = hotelJournal.Guest;
                SelectedRoom = hotelJournal.Room;
            }

        }

        private EntitiesModel<Guest> guests;

        private EntitiesModel<Room> rooms;
        public EntitiesModel<HotelJournal> HotelJournals { get; set; }

        public EntitiesModel<Guest> Guests
        {
            get
            {
                return guests;
            }
            set
            {
                guests = value;
            }
        }

        public EntitiesModel<Room> Rooms
        {
            get
            {
                return rooms;
            }
            set
            {
                rooms = value;
            }
        }

        public Room SelectedRoom { get; set; }

        public Guest SelectedGuest { get; set; }
        public override void createEntity(object obj)
        {
            EntitiesModel<HotelJournal> model = new EntitiesModel<HotelJournal>();
            Entity.Room = SelectedRoom;
            Entity.Guest = SelectedGuest;
            model.AddEntity(Entity, "api/hoteljournal");
        }
        public override void updateEntity(object obj)
        {
            EntitiesModel<HotelJournal> model = new EntitiesModel<HotelJournal>();
            Entity.Room = SelectedRoom;
            Entity.Guest = SelectedGuest;
            model.UpdateEntity(Entity, "api/hoteljournal" + "/" + Entity.Id);
        }

        public override bool canExecuteCreate()
        {
            return true;
        }
        public override bool canExecuteUpdate()
        {
            return true;
        }

        private void _updateRoomsList(object obj)
        {
            _updateList(ref rooms, "api/room");
        }

        private void _updateGuestsList(object obj)
        {
            _updateList(ref guests, "api/guest");
        }

        private void _updateList<Entity>(ref EntitiesModel<Entity> model, string address) where Entity : BaseEntity
        {
            if (model == null)
            {
                model = new EntitiesModel<Entity>();
            }
            model.Clear();
            var rawEntities = new ObservableCollection<Entity>(model.GetAllEntities(address));
            foreach (Entity rawEntity in rawEntities)
            {
                model.Add(rawEntity);
            }
        }


    }
}
