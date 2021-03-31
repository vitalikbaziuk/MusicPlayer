﻿using MusicPlayer.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.BLL.Interface
{
     public interface IAlbumService
    {
        IEnumerable<AlbumDTO> GetAllAlbums();
        void CreateNewAlbum(AlbumDTO albumDTO);
    }
}
