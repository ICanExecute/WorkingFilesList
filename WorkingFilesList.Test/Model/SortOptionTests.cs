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

using System.ComponentModel;
using NUnit.Framework;
using WorkingFilesList.Model;

namespace WorkingFilesList.Test.Model
{
    [TestFixture]
    public class SortOptionTests
    {
        [Test]
        public void SortDescriptionDisplayNameMatchesConstructorParameter()
        {
            // Arrange

            const string propertyName = "PropertyName";

            var option = new SortOption(
                "DisplayName",
                propertyName,
                ListSortDirection.Ascending);

            // Act

            var sortDescription = option.GetSortDescription();

            // Assert

            Assert.That(sortDescription.PropertyName, Is.EqualTo(propertyName));
        }

        [Test]
        public void SortDescriptionSortDirectionMatchesConstructorParameter()
        {
            // Arrange

            const ListSortDirection sortDirection = ListSortDirection.Descending;

            var option = new SortOption(
                "DisplayName",
                "PropertyName",
                sortDirection);

            // Act

            var sortDescription = option.GetSortDescription();

            // Assert

            Assert.That(sortDescription.Direction, Is.EqualTo(sortDirection));
        }
    }
}