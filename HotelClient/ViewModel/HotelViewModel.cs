using Entity.Entity;
using HotelClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelClient.ViewModel
{
    public class HotelViewModel : EntityViewModel<Hotel>
    {
        public HotelViewModel()
            : base(new Hotel())
        {

        }
        public HotelViewModel(Hotel hotel)
            : base(hotel)
        {
        }
        public override void createEntity(object obj)
        {
            EntitiesModel<Hotel> model = new EntitiesModel<Hotel>();
            model.AddEntity(Entity, "api/hotel");
        }
        public override void updateEntity(object obj)
        {
            EntitiesModel<Hotel> model = new EntitiesModel<Hotel>();
            model.UpdateEntity(Entity, "api/hotel" + "/" + Entity.Id);
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
