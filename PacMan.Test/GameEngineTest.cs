using System.IO;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace PacMan.Test
{
    public class GameEngineTest
    {
        private readonly ITestOutputHelper _output;
        private readonly GameEngine _sut;
        private readonly string _readAllText;
        private readonly PacMan _pacMan;

        public GameEngineTest(ITestOutputHelper output)
        {
            _output = output;
            _readAllText = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory() ,"KataPacman-seq.txt"));
            _pacMan = new PacMan(3, 5000);
            _sut = new GameEngine(_readAllText,_pacMan);
        }
        
        [Fact]
        public void should_read_the_sequence()
        {
            var sequence = _sut.ReadSequence(_readAllText);

            sequence.Should().HaveCount(82);
        }

        [Fact]
        public void should_step_forward()
        {
            _sut.MovePacMan();

            _sut.GameIndex.Should().Be(1);
        }

        [Fact]
        public void eating_dots_score_should_reis_of_10()
        {    
          _sut.MovePacMan();
            _pacMan.Score.Should().Be(5010);
        }
        
        [Fact]
        public void eating_VulnerableGhost_the_score_increase_by_2_times()
        {
            var pacMan = new PacMan(1, 0);
            var sut = new GameEngine("VulnerableGhost,VulnerableGhost,VulnerableGhost,VulnerableGhost", pacMan);
            sut.MovePacMan();
            pacMan.Score.Should().Be(200);// +200
            
            sut.MovePacMan();
            pacMan.Score.Should().Be(600);// +400

            sut.MovePacMan();
            pacMan.Score.Should().Be(1400);// +800
            
            sut.MovePacMan();
            pacMan.Score.Should().Be(3000);// +1600

        }
        
        [Fact]
        public void eating_InvincibleGhost_should_lost_live()
        {
            var pacMan = new PacMan(3, 0);
            var sut = new GameEngine("InvincibleGhost,InvincibleGhost,InvincibleGhost", pacMan);
            
            sut.MovePacMan();
            pacMan.Lives.Should().Be(2);
            sut.MovePacMan();
            pacMan.Lives.Should().Be(1);
            sut.MovePacMan();
            pacMan.Lives.Should().Be(0);

            pacMan.HasLives().Should().Be(false);

        }

        [Fact]
        public void the_game_should_run_until_pacman_has_lives()
        {
            var pacMan = new PacMan(1, 0);
            var sut = new GameEngine("Dot,Dot,InvincibleGhost", pacMan);

            pacMan.HasLives().Should().BeTrue();
            
            sut.MovePacMan();

            sut.CanContinue().Should().BeTrue();

            sut.MovePacMan();

            sut.CanContinue().Should().BeTrue();
            
            sut.MovePacMan();

            pacMan.HasLives().Should().BeFalse();

        }

        [Fact]
        public void the_game_should_run()
        {
            while (_sut.CanContinue())
            {
                _sut.MovePacMan();
                _output.WriteLine($"PacMan Score {_pacMan.Score} - Lives {_pacMan.Lives} - HasAlive {_pacMan.HasLives()}");
            }
            _output.WriteLine($"PacMan Score {_pacMan.Score} - Lives {_pacMan.Lives} - HasAlive {_pacMan.HasLives()}");
            
        }


        
    }
}