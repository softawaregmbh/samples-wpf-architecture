using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Sample.UI.Wpf.Tests
{
    [TestClass]
    public class MainViewModelTests
    {
        [TestMethod]
        public void SearchImages_CallsImageLogic()
        {
            var imageLogic = A.Fake<IImageLogic>();

            var images = new[]
            {
                new Image(),
                new Image()
            };

            A.CallTo(() => imageLogic.SearchImages(string.Empty)).Returns(images);

            var viewModel = new MainViewModel(imageLogic, A.Fake<IDialogService>());

            viewModel.SearchImages();

            A.CallTo(() => imageLogic.SearchImages(string.Empty)).MustHaveHappenedOnceExactly();

            CollectionAssert.AreEquivalent(images, viewModel.Images);
        }

        [TestMethod]
        public void DeleteImage_ConfirmNo_DoesNothing()
        {
            var imageLogic = A.Fake<IImageLogic>();
            var dialogService = A.Fake<IDialogService>();

            var images = new[]
            {
                new Image(),
                new Image()
            };

            A.CallTo(() => imageLogic.SearchImages(string.Empty)).Returns(images);
            A.CallTo(() => dialogService.Confirm(null, null)).WithAnyArguments().Returns(false);

            var viewModel = new MainViewModel(imageLogic, dialogService);

            viewModel.SearchImages();

            var imageToDelete = images.First();
            viewModel.SelectedImage = imageToDelete;
            viewModel.DeleteCommand.Execute(null);

            CollectionAssert.AreEquivalent(images, viewModel.Images);
            A.CallTo(() => imageLogic.DeleteImage(imageToDelete)).MustNotHaveHappened();
        }

        [TestMethod]
        public void DeleteImage_ConfirmYes_DeletesImage()
        {
            var imageLogic = A.Fake<IImageLogic>();
            var dialogService = A.Fake<IDialogService>();

            var images = new[]
            {
                new Image(),
                new Image()
            };

            A.CallTo(() => imageLogic.SearchImages(string.Empty)).Returns(images);
            A.CallTo(() => dialogService.Confirm(null, null)).WithAnyArguments().Returns(true);

            var viewModel = new MainViewModel(imageLogic, dialogService);

            viewModel.SearchImages();

            var imageToDelete = images.First();
            viewModel.SelectedImage = imageToDelete;
            viewModel.DeleteCommand.Execute(null);

            CollectionAssert.DoesNotContain(viewModel.Images, imageToDelete);
            Assert.AreEqual(viewModel.Images.Count, images.Length - 1);
            A.CallTo(() => imageLogic.DeleteImage(imageToDelete)).MustHaveHappenedOnceExactly();
        }
    }
}
