using System;
using AutoMapper;


namespace ProjetoEstagioSupDDD.MVC.AutoMapper
{
    public class AutoMapperConfig
    {
        //Registrar mapeamentos

        public static void RegisterMappings()
        {
            Mapper.Initialize(m =>
            {
                m.AddProfile<DominioParaViewModelMapper>();
                m.AddProfile<ViewModelParaDominioMapper>();
            });
        }
    }
}