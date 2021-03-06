﻿using System.Collections.Generic;
using System.Threading.Tasks;
using SibSoftProjectTest.Models;

namespace SibSoftProjectTest.Abstractions.Services
{
    public interface ICatsData
    {
        Task<List<ImageModel>> GetCats();
    }
}
