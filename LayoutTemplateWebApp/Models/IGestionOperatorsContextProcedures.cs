﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using LayoutTemplateWebApp.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace LayoutTemplateWebApp.Models
{
    public partial interface IGestionOperatorsContextProcedures
    {
        Task<int> CreateAdmOperatorAsync(int? idAdmOperator, string cellphone, string email, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> CreateClassroomAsync(string idClassroom, int? idFacilities, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> CreateEquipmentAsync(bool? availability, string name, string description, int? idUser, string condition, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> CreateFacilityAsync(int? idFacilities, int? capacity, int? idUser, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> CreateLaboratoryAsync(string idLaboratory, int? idFacilities, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> CreateOperatorAsync(string cellphone, string email, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> CreateUserAsync(int? idUser, string email, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> DeleteAdmOperatorAsync(int? idAdmOperator, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> DeleteClassroomAsync(string idClassroom, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> DeleteEquipmentAsync(int? idEquipment, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> DeleteFacilityAsync(int? idFacilities, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> DeleteLaboratoryAsync(string idLaboratory, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> DeleteOperatorAsync(string email, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> DeleteUserAsync(int? idUser, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<ReadAllAdmOperatorsResult>> ReadAllAdmOperatorsAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<ReadAllClassroomsResult>> ReadAllClassroomsAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<ReadAllEquipmentResult>> ReadAllEquipmentAsync(int? idEquipment, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<ReadAllFacilitiesResult>> ReadAllFacilitiesAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<ReadAllLaboratoriesResult>> ReadAllLaboratoriesAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<ReadAllUsersResult>> ReadAllUsersAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<ReadClassroomByIDResult>> ReadClassroomByIDAsync(string idClassroom, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<ReadEquipmentResult>> ReadEquipmentAsync(int? idEquipment, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<ReadFacilityByIDResult>> ReadFacilityByIDAsync(int? idFacilities, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<ReadLaboratoryByIDResult>> ReadLaboratoryByIDAsync(string idLaboratory, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<ReadOperatorResult>> ReadOperatorAsync(string email, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<ReadUserByIDResult>> ReadUserByIDAsync(int? idUser, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> UpdateAdmOperatorAsync(int? idAdmOperator, string cellphone, string email, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> UpdateClassroomAsync(string idClassroom, int? idFacilities, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> UpdateEquipmentAsync(int? idEquipment, bool? availability, string name, string description, int? idUser, string condition, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> UpdateFacilityAsync(int? idFacilities, int? capacity, int? idUser, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> UpdateLaboratoryAsync(string idLaboratory, int? idFacilities, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> UpdateUserAsync(int? idUser, string email, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
    }
}
