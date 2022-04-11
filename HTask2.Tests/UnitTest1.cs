using HTask2.GameSolve.Actions;
using HTask2.GameSolve.Interfaces;
using HTask2.GameSolve.Structures;
using HTask2.Tests.Mock;
using NUnit.Framework;
using System;

namespace HTask2.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void MovingObject()
        {
            Vector vectBef = new Vector();
            vectBef.PositionNow = new Coordinats { X = 12.0, Y = 5.0 };
            vectBef.Shift = new Coordinats { X = -7.0, Y = 3.0 };
            Movable movable = new MovableMock(vectBef);

            Assert.AreEqual(movable.CurrentVector.PositionNow.X, 12.0);
            Assert.AreEqual(movable.CurrentVector.PositionNow.Y, 5.0);

            Move move = new Move(movable);
            move.Execute();

            Assert.AreEqual(movable.CurrentVector.PositionNow.X, 5.0);
            Assert.AreEqual(movable.CurrentVector.PositionNow.Y, 8.0);
        }

        [Test]
        public void ShiftByNotPositionNaNX()
        {
            Vector vectBef = new Vector();
            vectBef.PositionNow = new Coordinats { X = double.NaN, Y = 0.0 };
            Movable movable = new MovableMock(vectBef);

            Move move = new Move(movable);
            try
            {
                move.Execute();
                Assert.Fail();
            }
            catch(Exception ex)
            {
                //Assert.AreEqual(ex.Message, "Íåâîçìîæíî ïðî÷èòàòü çíà÷åíèå êîîðäèíàòû X");
            }
        }

        [Test]
        public void ShiftByNotPositionInfX()
        {
            Vector vectBef = new Vector();
            vectBef.PositionNow = new Coordinats { X = double.PositiveInfinity, Y = 0.0 };
            Movable movable = new MovableMock(vectBef);

            Move move = new Move(movable);
            try
            {
                move.Execute();
                Assert.Fail();
            }
            catch (Exception ex)
            {
                //Assert.AreEqual(ex.Message, "Íåâîçìîæíî ïðî÷èòàòü çíà÷åíèå êîîðäèíàòû X");
            }
        }

        [Test]
        public void ShiftByNotPositionNaNY()
        {
            Vector vectBef = new Vector();
            vectBef.PositionNow = new Coordinats { X = 0.0, Y = double.NaN };
            Movable movable = new MovableMock(vectBef);

            Move move = new Move(movable);
            try
            {
                move.Execute();
                Assert.Fail();
            }
            catch (Exception ex)
            {
               // Assert.AreEqual(ex.Message, "Íåâîçìîæíî ïðî÷èòàòü çíà÷åíèå êîîðäèíàòû Y");
            }
        }

        [Test]
        public void ShiftByNotPositionInfY()
        {
            Vector vectBef = new Vector();
            vectBef.PositionNow = new Coordinats { X = 0.0, Y = double.PositiveInfinity };
            Movable movable = new MovableMock(vectBef);

            Move move = new Move(movable);
            try
            {
                move.Execute();
                Assert.Fail();
            }
            catch (Exception ex)
            {
                //Assert.AreEqual(ex.Message, "Íåâîçìîæíî ïðî÷èòàòü çíà÷åíèå êîîðäèíàòû Y");
            }
        }

        [Test]
        public void NotShiftObject()
        {
            Movable movable = null;

            Move move = new Move(movable);
            try
            {
                move.Execute();
                Assert.Fail();
            }
            catch (Exception ex)
            {
                //Assert.AreEqual(ex.Message, "Îáúåêò, ðåàëèçóþùèé èíòåðôåéñ Movable, íå îïðåäåëåí.");
            }
        }

        [Test]
        public void Rotate()
        {
            Vector vectBef = new Vector();
            vectBef.PositionNow = new Coordinats { X = 80.0, Y = 20.0 };
            vectBef.AngularVelosity = 10;
            vectBef.Direction = 15;
            vectBef.DirectionNumber = 24;

            Movable movable = new MovableMock(vectBef);
            Rotate rot = new Rotate(movable);

            Assert.AreEqual(movable.CurrentVector.Direction, 15);

            rot.Execute();

            Assert.AreEqual(movable.CurrentVector.Direction, 1);
            Assert.AreEqual(movable.CurrentVector.PositionNow.X, 80.0);
            Assert.AreEqual(movable.CurrentVector.PositionNow.Y, 20.0);
        }

        [Test]
        public void RotateWithoutPositionX()
        {
            Vector vectBef = new Vector();
            vectBef.PositionNow = new Coordinats { X = Double.NaN, Y = 20.0 };
            vectBef.AngularVelosity = 10;
            vectBef.Direction = 15;
            vectBef.DirectionNumber = 24;

            Movable movable = new MovableMock(vectBef);
            Rotate rot = new Rotate(movable);

            Assert.AreEqual(movable.CurrentVector.Direction, 15);

            try
            {
                rot.Execute();
                Assert.Fail();
            }
            catch(Exception ex)
            {
                //Assert.AreEqual(ex.Message, "Íåâîçìîæíî ïðî÷èòàòü çíà÷åíèå êîîðäèíàòû X");
            }
        }

        [Test]
        public void RotateWithoutPositionY()
        {
            Vector vectBef = new Vector();
            vectBef.PositionNow = new Coordinats { X = 5.0, Y = Double.PositiveInfinity };
            vectBef.AngularVelosity = 10;
            vectBef.Direction = 15;
            vectBef.DirectionNumber = 24;

            Movable movable = new MovableMock(vectBef);
            Rotate rot = new Rotate(movable);

            Assert.AreEqual(movable.CurrentVector.Direction, 15);

            try
            {
                rot.Execute();
                Assert.Fail();
            }
            catch (Exception ex)
            {
                //Assert.AreEqual(ex.Message, "Íåâîçìîæíî ïðî÷èòàòü çíà÷åíèå êîîðäèíàòû Y");
            }
        }

        //test
    }
}
