using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace HotelClient.Model
{
    public class EntitiesModel<EntityType> : ObservableCollection<EntityType> where EntityType : BaseEntity
    {
        public EntitiesModel()
        {
        }

        public void AddEntity(EntityType entity)
        {

        }
        public void DeleteEntity(EntityType entity)
        {

        }
        public void UpdateEntity(EntityType entity)
        {

        }

    }
}
