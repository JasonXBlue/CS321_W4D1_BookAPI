using System;
using System.Collections.Generic;
using System.Linq;
using CS321_W4D1_BookAPI.Data;
using CS321_W4D1_BookAPI.Models;

namespace CS321_W4D1_BookAPI.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly BookContext _bookContext;

        public PublisherService(BookContext bookContext)
        {
            _bookContext = bookContext;
        }

        public Publisher Add(Publisher Publisher)
        {
            _bookContext.Publishers.Add(Publisher);
            _bookContext.SaveChanges();
            return Publisher;
        }

        public Publisher Get(int id)
        {
            // return specified Publisher using Find()
            return _bookContext.Publishers.Find(id);
        }

        public IEnumerable<Publisher> GetAll()
        {
            // return all publishers using ToList()
            return _bookContext.Publishers.ToList();
        }

        public Publisher Update(Publisher updatedPublisher)
        {
            // get the Publisher object in the current list with this id
            var currentPublisher = _bookContext.Publishers.Find(updatedPublisher.Id);

            //return null if Publisher object to update not found
            if (currentPublisher == null) return null;

            // copy the property values from the changed publisher into the
            // one in the db. NOTE that this is much simpler than individually
            // copying each property.
            _bookContext.Entry(currentPublisher)
                .CurrentValues
                .SetValues(updatedPublisher);

            // update the publisher and save
            _bookContext.Publishers.Update(currentPublisher);
            _bookContext.SaveChanges();
            return currentPublisher;
        }

        public void Remove(Publisher Publisher)
        {
            // remove the publisher
            _bookContext.Publishers.Remove(Publisher);
            _bookContext.SaveChanges();
        }
    } 
}
