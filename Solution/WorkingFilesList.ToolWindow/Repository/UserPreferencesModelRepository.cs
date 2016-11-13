﻿// Working Files List
// Visual Studio extension tool window that shows a selectable list of files
// that are open in the editor
// Copyright © 2016 Anthony Fung

// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at

//     http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.Linq;
using WorkingFilesList.Core.Interface;
using WorkingFilesList.Core.Model;

namespace WorkingFilesList.ToolWindow.Repository
{
    public class UserPreferencesModelRepository : IUserPreferencesModelRepository
    {
        private readonly IOptionsLists _optionsLists;
        private readonly IStoredSettingsRepository _storedSettingsRepository;

        public UserPreferencesModelRepository(
            IOptionsLists optionsLists,
            IStoredSettingsRepository storedSettingsRepository)
        {
            _optionsLists = optionsLists;
            _storedSettingsRepository = storedSettingsRepository;
        }

        /// <summary>
        /// Overwrites all property values in <paramref name="model"/> with
        /// previously stored values
        /// </summary>
        /// <param name="model">
        /// User preferences model that will receive previously stored property
        /// values
        /// </param>
        public void LoadInto(IUserPreferences model)
        {
            model.AssignProjectColours = _storedSettingsRepository
                .GetAssignProjectColours();

            model.GroupByProject = _storedSettingsRepository
                .GetGroupByProject();

            model.HighlightFileName = _storedSettingsRepository
                .GetHighlightFileName();

            model.ShowFileTypeIcons = _storedSettingsRepository
                .GetShowFileTypeIcons();

            model.ShowRecentUsage = _storedSettingsRepository
                .GetShowRecentUsage();

            model.PathSegmentCount = _storedSettingsRepository
                .GetPathSegmentCount();

            var selectedDocumentSort = _storedSettingsRepository
                .GetSelectedDocumentSortType();

            model.SelectedDocumentSortOption = _optionsLists
                .DocumentSortOptions?.SingleOrDefault(d =>
                    d.DisplayName == selectedDocumentSort);

            var selectedProjectSort = _storedSettingsRepository
                .GetSelectedProjectSortType();

            model.SelectedProjectSortOption = _optionsLists
                .ProjectSortOptions?.SingleOrDefault(d =>
                    d.DisplayName == selectedProjectSort);
        }

        /// <summary>
        /// Store all property values in <paramref name="model"/>
        /// </summary>
        /// <param name="model">
        /// User preference model containing values with which to overwrite
        /// stored values with
        /// </param>
        public void SaveModel(IUserPreferences model)
        {
            _storedSettingsRepository.SetAssignProjectColours(model.AssignProjectColours);
            _storedSettingsRepository.SetGroupByProject(model.GroupByProject);
            _storedSettingsRepository.SetHighlightFileName(model.HighlightFileName);
            _storedSettingsRepository.SetShowFileTypeIcons(model.ShowFileTypeIcons);
            _storedSettingsRepository.SetShowRecentUsage(model.ShowRecentUsage);
            _storedSettingsRepository.SetPathSegmentCount(model.PathSegmentCount);

            _storedSettingsRepository.SetSelectedDocumentSortType(
                model.SelectedDocumentSortOption?.DisplayName);

            _storedSettingsRepository.SetSelectedProjectSortType(
                model.SelectedProjectSortOption?.DisplayName);
        }
    }
}
