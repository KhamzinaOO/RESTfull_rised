using Microsoft.VisualBasic;
using RESRTfull.Domain;
using System;

namespace RESTfull.API.DTO
{
    public class IndividualDTOMapper
    {
        public static IndividualDTO ToDto(Individual individual)
        {
            var individualDto = new IndividualDTO
            {
                ID = individual.ID
            };

            individualDto.InformationDTO=InformationDTOMapper.ToDto(individual.Information);

            foreach (var job in individual.Jobs)
            {
                individualDto.JobsDTOs.Add(JobDTOMapper.ToDto(job));
            }
            foreach (var education in individual.Educations)
            {
                individualDto.EducationsDTOs.Add(EducationDTOMapper.ToDto(education));
            }
            foreach (var document in individual.Documents)
            {
                individualDto.DocumentsDTOs.Add(DocumentDTOMapper.ToDto(document));
            }

            individualDto.ForeignPassportDTO=DocForeignPassportDTOMapper.ToDto(individual.ForeignPassport);
            individualDto.InternationalPassportDTO=DocInternationalPassportDTOMapper.ToDto(individual.InternationalPassport);
            individualDto.RussianPassportDTO = DocRussianPassportDTOMapper.ToDto(individual.RussianPassport);
            individualDto.PersonAddressDTO = AddressDTOMapper.ToDto(individual.PersonAddress);

            return individualDto;
        }

        public static Individual ToEntity(IndividualDTO individualDTO)
        {
            var individual = new Individual
            {
                ID = individualDTO.ID
            };

            var info = InformationDTOMapper.ToEntity(individualDTO.InformationDTO);
            info.Individual = individual;
            info.IndividualID = individual.ID;
            individual.AddInfo(info);

            foreach (var jobDTO in individualDTO.JobsDTOs)
            {
                var job = JobDTOMapper.ToEntity(jobDTO);
                job.Individual = individual;
                job.IndividualID = individual.ID;
                individual.AddJob(job);
            }
            foreach (var educationDTO in individualDTO.EducationsDTOs)
            {
                var education = EducationDTOMapper.ToEntity(educationDTO);
                education.Individual = individual;
                education.IndividualID = individual.ID;
                individual.AddEducation(education);
            }
            foreach (var documentDTO in individualDTO.DocumentsDTOs)
            {
                var document = DocumentDTOMapper.ToEntity(documentDTO);
                document.Individual = individual;
                document.IndividualID = individual.ID;
                individual.AddDocument(document);
            }

            var foreignPassport = DocForeignPassportDTOMapper.ToEntity(individualDTO.ForeignPassportDTO);
            foreignPassport.Individual = individual;
            foreignPassport.IndividualID = individual.ID;
            individual.AddForeignPassport(foreignPassport);

            var internationalPassport = DocInternationalPassportDTOMapper.ToEntity(individualDTO.InternationalPassportDTO);
            internationalPassport.Individual = individual;
            internationalPassport.IndividualID = individual.ID;
            individual.AddInternationalPassport(internationalPassport);

            var russianPassport = DocRussianPassportDTOMapper.ToEntity(individualDTO.RussianPassportDTO);
            russianPassport.Individual = individual;
            russianPassport.IndividualID = individual.ID;
            individual.AddRussianPassport(russianPassport);

            var address = AddressDTOMapper.ToEntity(individualDTO.PersonAddressDTO);
            address.Individual = individual;
            address.IndividualID = individual.ID;
            individual.AddAddress(address);

            return individual;
        }

        public static List<IndividualDTO> ToDto(List<Individual> individuals)
        {
            var individualDtos = new List<IndividualDTO>();
            foreach (var individual in individuals)
            {
                individualDtos.Add(ToDto(individual));
            }

            return individualDtos;
        }
    }
}
