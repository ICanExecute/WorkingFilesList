﻿// WorkingFilesList
// Visual Studio extension tool window that shows a selectable list of files
// that are open in the editor
// Copyright(C) 2016 Anthony Fung

// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.

// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.

// You should have received a copy of the GNU General Public License
// along with this program. If not, see<http://www.gnu.org/licenses/>.

using EnvDTE;
using System;
using WorkingFilesList.ToolWindow.ViewModel;

namespace WorkingFilesList.ToolWindow.Model
{
    public class DocumentMetadata : PropertyChangedNotifier
    {
        private string _displayName;

        /// <summary>
        /// Full path and name of document file, used for display purposes
        /// </summary>
        public string CorrectedFullName { get; }

        /// <summary>
        /// Substring of <see cref="CorrectedFullName"/> that is actually displayed
        /// </summary>
        public string DisplayName
        {
            get
            {
                return _displayName;
            }

            set
            {
                if (_displayName != value)
                {
                    _displayName = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Full path and name of document file, as reported by the <see cref="DTE"/>
        /// </summary>
        public string FullName { get; }

        /// <summary>
        /// Time when the document this metadata corresponds to was activated,
        /// i.e. the time that the document window received focus
        /// </summary>
        public DateTime ActivatedAt { get; set; }

        public DocumentMetadata(string correctedFullName, string fullName)
        {
            CorrectedFullName = correctedFullName;
            FullName = fullName;
        }
    }
}