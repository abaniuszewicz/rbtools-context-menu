﻿using RBToolsContextMenu.Application.Communication.DTO;
using RBToolsContextMenu.UI.Wpf.Models;
using RBToolsContextMenu.UI.Wpf.ViewModels;
using System;
using System.Linq;

namespace RBToolsContextMenu.UI.Wpf.Mapping
{
    public static class Mapper
    {
        public static RbtPostDto CreateDto(SendViewModel vm)
        {
            var dto = new RbtPostDto()
            {
                OpenBrowser = vm.OpenInBrowser,
                Publish = vm.Publish,
                SvnShowCopiesAsAdds = vm.SvnShowCopiesAsAdds,
                TargetGroups = vm.Groups.Where(g => g.IsSelected).Select(g => g.Display),
                TargetPeople = vm.People.Where(p => p.IsSelected).Select(p => p.Display),
                IncludePaths = Environment.GetCommandLineArgs().Skip(1),
            };

            if (!string.IsNullOrWhiteSpace(vm.Description))
                dto.Description = vm.Description;
            if (!string.IsNullOrWhiteSpace(vm.Summary))
                dto.Summary = vm.Summary;
            if (!string.IsNullOrWhiteSpace(vm.TestingDone))
                dto.TestingDone = vm.TestingDone;
            if (!string.IsNullOrWhiteSpace(vm.Repository))
                dto.Repository = vm.Repository;
            if (!string.IsNullOrWhiteSpace(vm.Server))
                dto.Server = vm.Server;

            if (vm.ReviewType == ReviewType.Update)
            {
                dto.Update = true;
                if (!string.IsNullOrWhiteSpace(vm.UpdateDescription))
                    dto.UpdateDescription = vm.UpdateDescription;
                if (!string.IsNullOrWhiteSpace(vm.ReviewId) && int.TryParse(vm.ReviewId, out int reviewId))
                    dto.ReviewRequestId = reviewId;
            }

            return dto;
        }
    }
}
