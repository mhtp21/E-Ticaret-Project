﻿using Core.Entities;

namespace Entities.Base
{
    public class BasicComment : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string Comment { get; set; }
    }
}