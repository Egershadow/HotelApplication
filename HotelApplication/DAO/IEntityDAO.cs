using Entity;
using System;
using System.Collections.Generic;

namespace HotelApplication.DAO
{
    public interface IEntityDAO<ObjType,KeyType> where ObjType : BaseEntity
                                   where KeyType : struct
    {
        void Create(ObjType objType);
        void Delete(KeyType keyType);
        void Update(KeyType keyType, ObjType objType);
        IEnumerable<ObjType> GetAll();
        ObjType GetObjectByID(KeyType keyType);
    }
}