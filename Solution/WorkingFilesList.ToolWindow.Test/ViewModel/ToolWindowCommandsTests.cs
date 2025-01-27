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

using EnvDTE80;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Windows.Input;
using WorkingFilesList.Core.Interface;
using WorkingFilesList.ToolWindow.Interface;
using WorkingFilesList.ToolWindow.ViewModel;
using WorkingFilesList.ToolWindow.ViewModel.Command;

namespace WorkingFilesList.ToolWindow.Test.ViewModel
{
    [TestFixture]
    public class ToolWindowCommandsTests
    {
        [Test]
        public void AllCommandsAreAssigned()
        {
            // Arrange

            var activateWindow = new ActivateWindow(
                Mock.Of<DTE2>(),
                Mock.Of<IDocumentMetadataEqualityService>(),
                Mock.Of<IDocumentMetadataManager>(),
                Mock.Of<IProjectItemService>());

            var closeDocument = new CloseDocument(
                Mock.Of<DTE2>(),
                Mock.Of<IDocumentMetadataEqualityService>());

            var openTestFile = new OpenTestFile(
                Mock.Of<IProjectItemService>(),
                Mock.Of<ITestFileNameEvaluator>());

            var openOptionsPage = new OpenOptionsPage();
            var toggleIsPinned = new ToggleIsPinned(Mock.Of<IDocumentMetadataManager>());

            var commandList = new List<ICommand>
            {
                activateWindow,
                closeDocument,
                openTestFile,
                openOptionsPage,
                toggleIsPinned
            };

            // Act

            var commands = new ToolWindowCommands(commandList);

            // Assert

            Assert.That(commands.ActivateWindow, Is.EqualTo(activateWindow));
            Assert.That(commands.CloseDocument, Is.EqualTo(closeDocument));
            Assert.That(commands.OpenOptionsPage, Is.EqualTo(openOptionsPage));
            Assert.That(commands.OpenTestFile, Is.EqualTo(openTestFile));
            Assert.That(commands.ToggleIsPinned, Is.EqualTo(toggleIsPinned));
        }
    }
}
