using Entity;
using HotelClient.Model;
using Microsoft.TeamFoundation.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HotelClient.ViewModel
{
    public abstract class EntityViewModel <EntityType> where EntityType: IBaseEntity
    {
        private ICommand createOrUpdateEntity;

        public EntityViewModel(EntityType entity)
        {
            this.Entity = entity;
            if(Entity == null || Entity.Id == 0) {

                ConstructorInfo ctor = null;
                ConstructorInfo[] constructorInfos = typeof(EntityType).GetConstructors();
                for (int i = 0; i < constructorInfos.Length; ++i)
                {
                    ParameterInfo[] constructorParams = constructorInfos[i].GetParameters();
                    if (constructorParams.Length == 0)
                    {
                        ctor = constructorInfos[i];
                    }                 
                }

                Entity = (EntityType)ctor.Invoke(null);
                createOrUpdateEntity = new RelayCommand(createEntity, param => canExecuteCreate());
            }
            else
            {
                createOrUpdateEntity = new RelayCommand(updateEntity, param => canExecuteUpdate());
            }
            
        }
        public EntityType Entity { get;set; }
        public Window View { get; set; }
        public ICommand CreateOrUpdateEntity
        {
            get
            {
                return createOrUpdateEntity;
            }
            set
            {
                createOrUpdateEntity = value;
            }
        }
        public String ButtonName
        {
            get
            {
                if (Entity == null || Entity.Id == 0)
                {
                    return "Create";
                }
                else
                {
                    return "Update";
                }
            }
        }
        //public EntitiesModel<EntityType> AllEntitiesModel { get; set; }
        public abstract void createEntity(object obj);
        public abstract void updateEntity(object obj);
        public abstract bool canExecuteCreate();
        public abstract bool canExecuteUpdate();
    }
}
