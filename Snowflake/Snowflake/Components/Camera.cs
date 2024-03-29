﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ComputerGraphics.Components
{
    public class Camera
    {
        public Matrix World { get; private set; }
        public Matrix View { get; private set; }
        public Matrix Projection { get; private set; }

        private Vector3 cameraPosition;

        private Vector3 cameraLookAt;

        private Vector3 cameraUpVector;

        private float cameraMovementSpeed;

        public Camera(int applicationWidth, int applicationHeight)
        {
            this.Initialize(applicationWidth, applicationHeight);
        }

        private void Initialize(int applicationWidth, int applicationHeight)
        {
            this.World = Matrix.CreateTranslation(0, 0, 0);

            this.cameraMovementSpeed = 0.1f;
            this.cameraPosition = new Vector3(0, 6, 6);
            this.cameraLookAt = new Vector3(0, 6, 0);
            this.cameraUpVector = Vector3.Up;
            // Matrx.CreateLookAt
            // P1: The position of the camera.
            // P2: The target towards which the camera is pointing.
            // P3: The direction that is "up" from the camera's point of view.
            this.View = Matrix.CreateLookAt(this.cameraPosition, this.cameraLookAt, this.cameraUpVector);
            this.Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), (float)applicationWidth / (float)applicationHeight, 0.01f, 1000f); // TODO: calculate aspect ratio
        }

        public void Update()
        {
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.A))
            {
                this.cameraPosition.X -= this.cameraMovementSpeed;
                this.cameraLookAt.X -= this.cameraMovementSpeed;
                this.View = Matrix.CreateLookAt(this.cameraPosition, this.cameraLookAt, this.cameraUpVector);
            }
            else if (state.IsKeyDown(Keys.D))
            {
                this.cameraPosition.X += this.cameraMovementSpeed;
                this.cameraLookAt.X += this.cameraMovementSpeed;
                this.View = Matrix.CreateLookAt(this.cameraPosition, this.cameraLookAt, this.cameraUpVector);
            }
            else if (state.IsKeyDown(Keys.W))
            {
                this.cameraPosition.Y += this.cameraMovementSpeed;
                this.cameraLookAt.Y += this.cameraMovementSpeed;
                this.View = Matrix.CreateLookAt(this.cameraPosition, this.cameraLookAt, this.cameraUpVector);
            }
            else if (state.IsKeyDown(Keys.S))
            {
                this.cameraPosition.Y -= this.cameraMovementSpeed;
                this.cameraLookAt.Y -= this.cameraMovementSpeed;
                this.View = Matrix.CreateLookAt(this.cameraPosition, this.cameraLookAt, this.cameraUpVector);
            }
            else if (state.IsKeyDown(Keys.LeftShift))
            {
                this.cameraPosition.Z -= this.cameraMovementSpeed;
                this.cameraLookAt.Z -= this.cameraMovementSpeed;
                this.View = Matrix.CreateLookAt(this.cameraPosition, this.cameraLookAt, this.cameraUpVector);
            }
            else if (state.IsKeyDown(Keys.Space))
            {
                this.cameraPosition.Z += this.cameraMovementSpeed;
                this.cameraLookAt.Z += this.cameraMovementSpeed;
                this.View = Matrix.CreateLookAt(this.cameraPosition, this.cameraLookAt, this.cameraUpVector);
            }
        }

    }
}
