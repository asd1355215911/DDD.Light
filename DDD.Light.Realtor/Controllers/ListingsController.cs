﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DDD.Light.Realtor.Models;
using DDD.Light.Repo.Contracts;

namespace DDD.Light.Realtor.Controllers
{
    public class ListingsController : ApiController
    {
        private readonly IRepository<Listing> _listingRepository;

        public ListingsController(IRepository<Listing> listingRepository)
        {
            _listingRepository = listingRepository;
        }

        // GET api/listings
        public IEnumerable<Listing> Get()
        {
            return _listingRepository.GetAll();
        }

        // GET api/listings/ecf4dbf5-b8b2-4529-84bc-4117cf106227
        public Listing Get(Guid id)
        {
            return _listingRepository.GetById(id);
        }

        // POST api/listings
        public HttpResponseMessage Post(Listing listing)
        {
            listing.Id = Guid.NewGuid();

            try
            {
                _listingRepository.Save(listing);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
            return Request.CreateResponse(HttpStatusCode.Created, listing);
        }

        // PUT api/listings/5
        public HttpResponseMessage Put(Listing listing)
        {
            if (listing.Id == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Id is missing. Use POST or provide Id.");
            try
            {
                _listingRepository.Save(listing);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, listing);
        }

        // DELETE api/listings/5
        public HttpResponseMessage Delete(Guid id)
        {
            try
            {
                _listingRepository.Delete(id);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
    }
}