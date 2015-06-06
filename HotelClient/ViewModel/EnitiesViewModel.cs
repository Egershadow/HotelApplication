using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.TeamFoundation.MVVM;
using HotelClient.Model;
using Entity;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Reflection;

namespace HotelClient.ViewModel
{
    public class EntitiesViewModel<EntityType, ViewCreateUpdateType, EntityModelType> : ViewModelBase
        where EntityType : BaseEntity
        where ViewCreateUpdateType : Window, new()
        where EntityModelType : EntityViewModel <EntityType>,new()
    {
        private ICommand showCreateEntityCommand;
        private ICommand deleteEntityCommand;
        private ICommand showUpdateEntityCommand;
        private ICommand updateEntityListCommand;

        private bool canUpdateEntityListCommand = true;
        //private GuestWindow guestWindow;
        private ViewCreateUpdateType creatorWindow;
        private EntitiesModel<EntityType> entities;
        private EntityType selectedItem;
        protected String entityAddress = "";


        public EntityType SelectedItem
        {
            get 
            { 
                return selectedItem; 
            }
            set
            {
                selectedItem = value;
            }
        }


        public ICommand ShowCreateEntityCommand
        {
            get
            {
                return showCreateEntityCommand;
            }
            set
            {
                showCreateEntityCommand = value;
            }
        }

        public ICommand DeleteEntityCommand
        {
            get
            {
                return deleteEntityCommand;
            }
            set
            {
                deleteEntityCommand = value;
            }
        }

        public ICommand ShowUpdateEntityCommand
        {
            get
            {
                return showUpdateEntityCommand;
            }
            set
            {
                showUpdateEntityCommand = value;
            }
        }

        public ICommand UpdateEntityListCommand
        {
            get
            {
                return updateEntityListCommand;
            }
            set
            {
                updateEntityListCommand = value;
            }
        }

        public EntitiesModel<EntityType> Entities
        {
            get
            {
                return entities;
            }
            set
            {
                entities = value;
            }
        }


        public EntitiesViewModel()
        {
            //Type objType = obj.GetType();
            //if (objType.ToString() != entity.GetType().ToString())
            //{
            //    Exception e = new Exception("EntityService.CopyAllFieldsFrom type mismatch");
            //    throw e;
            //}
            //PropertyInfo[] properties = objType.GetProperties();
            //foreach (PropertyInfo property in properties)
            //{
            //    PropertyInfo entityProperty = entity.GetType().GetProperty(property.Name);
            //    property.SetValue(obj, entityProperty.GetValue(entity, null));
            //}


            creatorWindow = null;
            entities = new EntitiesModel<EntityType>();
            //updateEntityList(new Object());

            showCreateEntityCommand = new RelayCommand(showCreateUpdateWindow, param => this.canShowCreateWindow());
            showUpdateEntityCommand = new RelayCommand(showCreateUpdateWindow, param => this.canShowUpdateWindow());
            deleteEntityCommand = new RelayCommand(deleteEntity, param => this.canExecuteDelete());
            updateEntityListCommand = new RelayCommand(updateEntityList, param => this.canUpdateEntityListCommand);

        }

        public void showCreateUpdateWindow(object obj) 
        {
            creatorWindow = new ViewCreateUpdateType();
            EntityModelType entityViewModel;
            ConstructorInfo ctor = null;
            ConstructorInfo[] constructorInfos = typeof(EntityModelType).GetConstructors();
            for(int i = 0; i < constructorInfos.Length;++i ) 
            {
                ParameterInfo[] constructorParams = constructorInfos[i].GetParameters();
                if (constructorParams.Length == 0) 
                {
                    continue;
                }
                else
                {
                    if (constructorParams[0].ParameterType.Name.Equals("Guest") && constructorParams.Length == 1)
                    {
                        ctor = constructorInfos[i];
                        break;
                    }
                }
            }
            if(ctor == null) {
                return;
            } 
            //= new EntityModelType(selectedItem);
            entityViewModel = (EntityModelType)ctor.Invoke(new object[] { selectedItem });
            entityViewModel.View = creatorWindow;
            creatorWindow.DataContext = entityViewModel;
            creatorWindow.ShowDialog();
            updateEntityList(null);
            
            //guestWindow = new GuestWindow();
            //guestWindow.Show();
            
        }

        //public void showUpdateWindow(object obj)
        //{
        //    creatorWindow = new ViewCreateUpdateType();
        //    EntityModelType entityModel = new EntityModelType();
        //    creatorWindow.DataContext = entityModel;
        //    creatorWindow.Show();
        //    //guestWindow = new GuestWindow();
        //    //guestWindow.Show();
        //}

        public void deleteEntity(object obj)
        {
            entities.DeleteEntity((EntityType)SelectedItem, entityAddress);
            updateEntityList(null);
        }

        public void updateEntityList(object obj)
        {
            Entities.Clear();
            EntitiesModel<EntityType> eM = new EntitiesModel<EntityType>();
            var rawEntities = new ObservableCollection<EntityType>(eM.GetAllEntities(entityAddress));
            foreach (EntityType rawEntity in rawEntities)
            {
                Entities.Add(rawEntity);
            }
            //TODO: set gotten list to EntitiesModel
            //entities = entities.GetAllEntities(entityAddress);
        }

        public bool canShowCreateWindow()
        {
            return true;
        }

        public bool canShowUpdateWindow()
        {
            if (selectedItem == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool canExecuteDelete()
        {
            if (selectedItem == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
