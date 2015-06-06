using Entity.Entity;
using HotelClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelClient.ViewModel
{
    public class GuestViewModel : EntityViewModel<Guest>
    {
        public GuestViewModel()
            : base(new Guest())
        {

        }
        public GuestViewModel(Guest guest)
            : base(guest)
        {
        }
        public override void createEntity(object obj) 
        {
            EntitiesModel<Guest> model = new EntitiesModel<Guest>();
            model.AddEntity(Entity, "api/guest");
        }
        public override void updateEntity(object obj)
        {
            EntitiesModel<Guest> model = new EntitiesModel<Guest>();
            model.UpdateEntity(Entity, "api/guest" + "/" + Entity.Id);
        }

        public override bool canExecuteCreate()
        {
            return true;
        }
        public override bool canExecuteUpdate()
        {
            return true;
        }
    }
}
