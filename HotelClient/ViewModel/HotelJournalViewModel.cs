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
        private EntitiesService<Room> roomsService;
        private EntitiesService<Guest> guestsService;

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

        private ObservableCollection<Guest> guests;

        private ObservableCollection<Room> rooms;
        public EntitiesService<HotelJournal> HotelJournals { get; set; }

        public ObservableCollection<Guest> Guests
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

        public ObservableCollection<Room> Rooms
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
            EntitiesService<HotelJournal> model = new EntitiesService<HotelJournal>();
            Entity.Room = SelectedRoom;
            Entity.Guest = SelectedGuest;
            model.AddEntity(Entity, "api/hoteljournal");
        }
        public override void updateEntity(object obj)
        {
            EntitiesService<HotelJournal> model = new EntitiesService<HotelJournal>();
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
            _updateList(ref rooms, ref roomsService, "api/room");
        }

        private void _updateGuestsList(object obj)
        {
            _updateList(ref guests, ref guestsService, "api/guest");
        }

        private void _updateList<Entity>(ref ObservableCollection<Entity> model, ref EntitiesService<Entity> service, string address) where Entity : BaseEntity
        {
            if (model == null)
            {
                model = new ObservableCollection<Entity>();
            }
            model.Clear();
            var rawEntities = new ObservableCollection<Entity>(service.GetAllEntities(address));
            foreach (Entity rawEntity in rawEntities)
            {
                model.Add(rawEntity);
            }
        }


    }
}
