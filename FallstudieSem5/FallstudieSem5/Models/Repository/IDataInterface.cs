﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FallstudieSem5.Models.Repository
{
  public interface IDataRepository<TEntity>
  {
    IEnumerable<TEntity> GetAll();
    TEntity Get(long id);
    void Add(TEntity entity);
    void Update(TEntity dbEntity, TEntity entity);
    void Delete(TEntity entity);
  }
}