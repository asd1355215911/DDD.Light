﻿using DDD.Light.Realtor.Domain.Model;

namespace DDD.Light.Realtor.Domain.Events
{
    public class OfferMade
    {
        public Offer Offer { get; set; }
    }
}