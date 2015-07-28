using System;
using CodemashApp.Configuration;
using CodemashApp.Repository;

namespace CodemashApp.UnitOfWork
{
    public class CodemashUnitOfWork
    {
        private static CacheSessionRepository _sessionRepository;
        private static CacheSpeakerRepository _speakerRepository;

        #region Repositories

        public CacheSessionRepository SessionRepository
        {
            get
            {
                return _sessionRepository
                       ?? (_sessionRepository = 
                        new CacheSessionRepository(
                            new Uri(CodemashConfiguration.SessionUrl)));
            }
        }

        public CacheSpeakerRepository SpeakerRepository
        {
            get
            {
                return _speakerRepository
                       ?? (_speakerRepository =
                        new CacheSpeakerRepository(
                            new Uri(CodemashConfiguration.SpeakerUrl)));
            }
        }

        #endregion

    }
}