using AutoMapper;
using System.Linq;
using MyVegaApi.Controllers.Resources;
using MyVegaApi.Models;
using System.Collections.Generic;

namespace MyVegaApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to API Resource
            CreateMap<Make, MakeResource>();
            CreateMap<Make, KeyValuePairResource>();
            CreateMap<Model, KeyValuePairResource>();
            CreateMap<Feature, KeyValuePairResource>();
            CreateMap<Vehicle, SaveVehicleResource>()
              .ForMember(vr => vr.Contact, opt => opt.MapFrom(v => new ContactResource { Name = v.ContactName, Email = v.ContactEmail, Address = v.ContactAddress }))
              .ForMember(vr=> vr.Id,opt=> opt.MapFrom(v=>v.VehicleID))
              .ForMember(vr => vr.Features, opt => opt.MapFrom(v => v.Features.Select(vf => vf.FeatureID)));

            CreateMap<Vehicle, VehicleResource>()
              .ForMember(vr => vr.Make, opt => opt.MapFrom(v => v.Model.Make))
               .ForMember(vr => vr.Id, opt => opt.MapFrom(v => v.VehicleID))
              .ForMember(vr => vr.Contact, opt => opt.MapFrom(v => new ContactResource { Name = v.ContactName, Email = v.ContactEmail, Address = v.ContactAddress }))
              .ForMember(vr => vr.Features, opt => opt.MapFrom(v => v.Features.Select(vf => new KeyValuePairResource { Id = vf.Feature.Id, Name = vf.Feature.Name })));

            // API Resource to Domain
            CreateMap<SaveVehicleResource, Vehicle>()
              .ForMember(v => v.VehicleID, opt => opt.Ignore())
              .ForMember(v => v.ContactName, opt => opt.MapFrom(vr => vr.Contact.Name))
              .ForMember(v => v.ContactEmail, opt => opt.MapFrom(vr => vr.Contact.Email))
              .ForMember(v => v.ContactAddress, opt => opt.MapFrom(vr => vr.Contact.Address))
              .ForMember(v => v.Features, opt => opt.Ignore())
              .AfterMap((vr, v) =>
              {
              // Remove unselected features
              var removedFeatures = v.Features.Where(f => !vr.Features.Contains(f.FeatureID)).ToList();
                  foreach (var f in removedFeatures)
                      v.Features.Remove(f);

              // Add new features
              var addedFeatures = vr.Features.Where(id => !v.Features.Any(f => f.FeatureID == id)).Select(id => new VehicleFeatures { FeatureID = id }).ToList();
                  foreach (var f in addedFeatures)
                      v.Features.Add(f);
              });
        }
    }
}