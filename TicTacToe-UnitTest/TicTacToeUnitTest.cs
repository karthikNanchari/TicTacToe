using Moq;
using System;
using System.Collections.Generic;
using TicTacToe;
using Xunit;

namespace TicTacToe_UnitTest
{
    /// <summary>
    /// Xunit Test cases for TicTacToe project
    /// </summary>
    public class TicTacToeUnitTest
    {

        /// <summary>
        /// Verify if ChoosePlayerChoice returns value
        /// </summary>
        [Fact]
        public void ChoosePlayerChoice_NotNull()
        {
            // Arrange
            var iGameMock = new Mock<IGame>();
            iGameMock.Setup(m => m.ChoosePlayerChoice(It.IsAny<int>())).Returns("Player 1's Turn");

            // Act
            string playerDetail = iGameMock.Object.ChoosePlayerChoice(3);

            //Assert
            Assert.Equal("Player 1's Turn", playerDetail);
            Assert.NotEmpty( playerDetail);
        }

        /// <summary>
        /// Verify if GetSuccessRows are returned 
        /// </summary>
        [Fact]
        public void GetSuccessRows_NotNull()
        {
            // Arrange
            List<int[]> successRows = new List<int[]> { new[] { 1, 2, 3 }, new[] { 4, 5, 6 } };
            var iCommonMock = new Mock<ICommon>();
            iCommonMock.Setup(m => m.GetSuccessRows()).Returns(successRows);

            // Act
            int successRowsCount = iCommonMock.Object.GetSuccessRows().Count;

            //Assert
            Assert.True(successRowsCount > 0, "List count is greater than 0 all the time");
            Assert.NotNull(iCommonMock.Object.GetSuccessRows());
        }

        /// <summary>
        /// DisplayAllPlayerChoices
        /// </summary>
        [Fact]
        public void DisplayAllPlayerChoices_IsVerifiable()
        {
            // Arrange
            var iGameMoveMock = new Mock<IGameMove>();
            iGameMoveMock.Setup(m => m.DisplayAllPlayerChoices(It.IsAny<int>())).Verifiable();

            // Act
            iGameMoveMock.Object.DisplayAllPlayerChoices(5);

            //Assert
            iGameMoveMock.Verify(m => m.DisplayAllPlayerChoices(It.IsAny<int>()), Times.Once);
        }

    }
}
