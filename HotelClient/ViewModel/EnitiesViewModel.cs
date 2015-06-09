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
using HotelClient.Service;

namespace HotelClient.ViewModel
{
    public class EntitiesViewModel<EntityType,DialogService,EntityModelType> : ViewModelBase
        where EntityType : BaseEntity, new()
        where DialogService : HotelClient.Service.IDialogService, new()
        where EntityModelType : EntityViewModel <EntityType>,new()
    {
        private ICommand showCreateEntityCommand;
        private ICommand deleteEntityCommand;
        private ICommand showUpdateEntityCommand;
        private ICommand updateEntityListCommand;

        private bool canUpdateEntityListCommand = true;
        private HotelClient.Service.IDialogService dialogService;
        private ObservableCollection<EntityType> entities;
        
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

        public ObservableCollection<EntityType> Entities
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

        public EntitiesService<EntityType> EntityService { get; set; }

        public EntitiesViewModel()
        {

            EntityService = new EntitiesService<EntityType>();
            entities = new ObservableCollection<EntityType>();

            showCreateEntityCommand = new RelayCommand(showCreateUpdateWindow, param => this.canShowCreateWindow());
            showUpdateEntityCommand = new RelayCommand(showCreateUpdateWindow, param => this.canShowUpdateWindow());
            deleteEntityCommand = new RelayCommand(deleteEntity, param => this.canExecuteDelete());
            updateEntityListCommand = new RelayCommand(updateEntityList, param => this.canUpdateEntityListCommand);

        }

        public void showCreateUpdateWindow(object obj) 
        {
            dialogService = (HotelClient.Service.IDialogService)new DialogService();
            EntityModelType entityViewModel;
            ConstructorInfo ctor = null;
            string parameterName = "";
            ConstructorInfo[] entityConstructorInfos = typeof(EntityType).GetConstructors();
            foreach (ConstructorInfo info in entityConstructorInfos)
            {
                if(info.GetParameters().Length == 0) {
                    EntityType typo = (EntityType)info.Invoke(null);
                    parameterName = typo.GetType().Name;
                    break;
                }
            }
            if (parameterName == "")
            {
                return;
            }
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
                    if (constructorParams[0].ParameterType.Name.Equals(parameterName) && constructorParams.Length == 1)
                    {
                        ctor = constructorInfos[i];
                        break;
                    }
                }
            }
            if(ctor == null) {
                return;
            } 
            entityViewModel = (EntityModelType)ctor.Invoke(new object[] { selectedItem });
            dialogService.ShowDialog(entityViewModel);
            updateEntityList(null);
            
        }

        public void deleteEntity(object obj)
        {
            EntityService.DeleteEntity((EntityType)SelectedItem, entityAddress);
            updateEntityList(null);
        }

        public void updateEntityList(object obj)
        {
            Entities.Clear();
            EntitiesService<EntityType> eM = new EntitiesService<EntityType>();
            var rawEntities = new ObservableCollection<EntityType>(eM.GetAllEntities(entityAddress));
            foreach (EntityType rawEntity in rawEntities)
            {
                Entities.Add(rawEntity);
            }
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
