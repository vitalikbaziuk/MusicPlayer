﻿using AutoMapper;
using MusicPlayer.BLL.DTO;
using MusicPlayer.BLL.Interface;
using MusicPlayer.DAL.Entities;
using MusicPlayer.DAL.Interfaces;
using MusicPlayer.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.BLL.Service
{
    public class СategoryService : IСategoryService
    {
        private IUnitOfWork repositories;
        private IMapper mapper;
        public СategoryService()
        {
            this.repositories = new UnitOfWork();

            IConfigurationProvider config = new MapperConfiguration(
                cfg =>
                {
                    // Entity to DTO
                    cfg.CreateMap<Album, AlbumDTO>();
                    cfg.CreateMap<Artist, ArtistDTO>();
                    cfg.CreateMap<Сategory, СategoryDTO>();
                    cfg.CreateMap<Track, TrackDTO>();

                    // DTO to Entity
                    cfg.CreateMap<AlbumDTO, Album>();
                    cfg.CreateMap<ArtistDTO, Artist>();
                    cfg.CreateMap<СategoryDTO, Сategory>();
                    cfg.CreateMap<TrackDTO, Track>();
                });

            mapper = new Mapper(config);
        }

        // Public Service Interface
        public IEnumerable<СategoryDTO> GetAllСategorys()
        {
            var result = repositories.СategoryRepos.Get();
            return mapper.Map<IEnumerable<СategoryDTO>>(result);
        }

        public void CreateNewСategory(СategoryDTO categoryDTO)
        {
            repositories.СategoryRepos.Insert(mapper.Map<Сategory>(categoryDTO));
            repositories.Save();
        }
    }
}