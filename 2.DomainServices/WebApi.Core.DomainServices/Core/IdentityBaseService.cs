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

namespace Net.Core.DomainServices.Core
{
    public abstract class IdentityBaseService<T,VM> : BaseService<T, VM>, IIdentityBaseService<T,VM> where T:IdentityColumnEntity where VM:IdentityColumnViewModel
    {
        [SetterProperty]
        public IIdentityBaseRepository<T> IdentityBaseRepository
        {
            get; set;
        }

        public override ResponseResults<VM> GetAll()
        {
            var response = new ResponseResults<VM>() { IsSucceed  =true, Message = AppMessages.Retrieved_Details_Successfully};
            try
            {
                var models = UnitOfWork.SetDbContext(IdentityBaseRepository).GetAll();
                response.ViewModels = models.ToViewModel<T, VM>().ToList();
            }
            catch (Exception ex)
            {
                response.IsSucceed = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public virtual ResponseResult<VM> GetById(long id)
        {
            var response = new ResponseResult<VM>() { IsSucceed = true, Message = AppMessages.Retrieved_Details_Successfully };
            try
            {
                var model = UnitOfWork.SetDbContext(IdentityBaseRepository).FindById(id);
                response.ViewModel = model.ToViewModel<T, VM>();
            }
            catch (Exception ex)
            {
                response.IsSucceed = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public override ResponseResult<VM> Save(VM viewModel)
        {
            var response = new ResponseResult<VM>() { IsSucceed = true, Message = AppMessages.Saved_Details_Successfully };
            try
            {
                T model = viewModel.ToEntityModel<T,VM>();
            
                if (viewModel.Id == 0)
                {
                    UnitOfWork.SetDbContext(IdentityBaseRepository).Add(model);
                }
                else
                {
                    UnitOfWork.SetDbContext(IdentityBaseRepository).Update(model);
                }

                UnitOfWork.Commit();
                response.ViewModel = model.ToViewModel<T, VM>();
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
