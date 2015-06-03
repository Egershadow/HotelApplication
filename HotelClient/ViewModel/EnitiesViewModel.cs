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

namespace HotelClient.ViewModel
{
    public class EntitiesViewModel<EntityType, ViewCreateUpdateType> : ViewModelBase
        where EntityType : BaseEntity
        where ViewCreateUpdateType : Window, new()
    {
        private ICommand showCreateEntityCommand;
        private ICommand deleteEntityCommand;
        private ICommand showUpdateEntityCommand;
        private ICommand updateEntityListCommand;

        private bool canShowCreateEntityCommand = true;
        private bool canShowUpdateEntityCommand = false;
        private bool canDeleteEntityCommand = false;
        private bool canUpdateEntityListCommand = true;
        private GuestWindow guestWindow;
        private ViewCreateUpdateType creatorWindow;
        private EntitiesModel<EntityType> entities;
        private EntityType selectedItem;
        protected String entityAddress = "";


        public EntityType SelectedItem
        {
            get { return selectedItem; }
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
            updateEntityList(new Object());

            showCreateEntityCommand = new RelayCommand(showCreateWindow, param => this.canShowCreateEntityCommand);
            showUpdateEntityCommand = new RelayCommand(showUpdateWindow, param => this.canShowUpdateEntityCommand);
            deleteEntityCommand = new RelayCommand(deleteEntity, param => this.canDeleteEntityCommand);
            updateEntityListCommand = new RelayCommand(updateEntityList, param => this.canUpdateEntityListCommand);

        }

        public void showCreateWindow(object obj) 
        {
            creatorWindow = new ViewCreateUpdateType();
            creatorWindow.DataContext = this;
            creatorWindow.Show();
            //guestWindow = new GuestWindow();
            //guestWindow.Show();
        }

        public void showUpdateWindow(object obj)
        {
            creatorWindow = new ViewCreateUpdateType();
            creatorWindow.DataContext = this;
            creatorWindow.Show();
            //guestWindow = new GuestWindow();
            //guestWindow.Show();
        }

        public void deleteEntity(object obj)
        {
            entities.DeleteEntity((EntityType)obj, entityAddress);
        }

        public void updateEntityList(object obj)
        {
            //TODO: set gotten list to EntitiesModel
            //entities = entities.GetAllEntities(entityAddress);
        }

    }
}
