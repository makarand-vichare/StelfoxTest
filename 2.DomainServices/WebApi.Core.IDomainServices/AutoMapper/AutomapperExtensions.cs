using AutoMapper;
using System.Collections.Generic;
using Net.Core.EntityModels.Core;
using Net.Core.ViewModels.Core;

namespace Net.Core.IDomainServices.AutoMapper
{
    public static class AutomapperExtensions
    {
        public static VM ToViewModel<T, VM>(this T model, IMapper mapper)
        {
            return mapper.Map<T, VM>(model);
        }

        public static T ToEntityModel<T, VM>(this VM viewModel, IMapper mapper)
        {
            return mapper.Map<VM, T>(viewModel);
        }

        public static VM ToViewModel<VM>(this BaseEntity entity, IMapper mapper) where VM : BaseViewModel
        {
            return (VM)mapper.Map(entity, entity.GetType(), typeof(VM));
        }

        public static T ToEntityModel<T>(this BaseViewModel entity, IMapper mapper) where T : BaseEntity
        {
            return (T)mapper.Map(entity, entity.GetType(), typeof(T));
        }

        public static IEnumerable<VM> ToViewModel<T, VM>(this IEnumerable<T> models, IMapper mapper)
        {
            return mapper.Map<IEnumerable<T>, IEnumerable<VM>>(models);
        }

        public static IEnumerable<T> ToEntityModel<T, VM>(this IEnumerable<VM> viewModels, IMapper mapper)
        {
            return mapper.Map<IEnumerable<VM>, IEnumerable<T>>(viewModels);
        }

        public static List<VM> ToViewModel<VM>(this IEnumerable<BaseEntity> entity, IMapper mapper) where VM : BaseViewModel
        {
            return (List<VM>)mapper.Map(entity, entity.GetType(), typeof(VM));
        }

        public static List<T> ToEntityModel<T>(this IEnumerable<BaseViewModel> entity, IMapper mapper) where T : BaseEntity
        {
            return (List<T>)mapper.Map(entity, entity.GetType(), typeof(T));
        }

    }
}
