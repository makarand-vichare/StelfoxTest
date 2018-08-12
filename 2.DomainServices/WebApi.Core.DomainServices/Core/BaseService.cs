using StructureMap.Attributes;
using System;
using System.Linq;
using Net.Core.EntityModels.Core;
using Net.Core.IDomainServices.AutoMapper;
using Net.Core.IDomainServices.Core;
using Net.Core.IRepositories.Core;
using Net.Core.ServiceResponse;
using Net.Core.Utility;
using Net.Core.ViewModels.Core;
using AutoMapper;

namespace Net.Core.DomainServices.Core
{
    public abstract class BaseService<T,VM> : IBaseService<T,VM> where T:BaseEntity where VM:BaseViewModel
    {
        [SetterProperty]
        public IBaseRepository<T> BaseRepository
        {
            get; set;
        }

        [SetterProperty]
        public IUnitOfWork UnitOfWork
        {
            get; set;
        }

        [SetterProperty]
        public IMapper Mapper
        {
            get; set;
        }

        public virtual ResponseResults<VM> GetAll()
        {
            var response = new ResponseResults<VM>() { IsSucceed  =true, Message = AppMessages.Retrieved_Details_Successfully};
            try
            {
                var models = UnitOfWork.SetDbContext(BaseRepository).GetAll();
                response.ViewModels = models.ToViewModel<T, VM>(Mapper).ToList();
            }
            catch (Exception ex)
            {
                response.IsSucceed = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public virtual ResponseResult<VM> Save(VM viewModel)
        {
            var response = new ResponseResult<VM>() { IsSucceed = true, Message = AppMessages.Saved_Details_Successfully };
            try
            {
                T model = viewModel.ToEntityModel<T,VM>(Mapper);
            
                //if (viewModel.Id == 0)
                //{
                //    UnitOfWork.SetDbContext(BaseRepository).Add(model);
                //}
                //else
                //{
                    UnitOfWork.SetDbContext(BaseRepository).Update(model);
                //}

                UnitOfWork.Commit();
                response.ViewModel = model.ToViewModel<T, VM>(Mapper);
            }
            catch (Exception ex)
            {
                response.IsSucceed = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
