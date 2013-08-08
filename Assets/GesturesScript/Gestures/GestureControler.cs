// -----------------------------------------------------------------------
// <copyright file="GestureControler.cs" company="Microsoft Limited">
//  Copyright (c) Microsoft Limited, Microsoft Consulting Services, UK. All rights reserved.
// All rights reserved.
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>The gesture controler</summary>
//-----------------------------------------------------------------------
//namespace KinectSkeltonTracker.Gestures
//{
    #region using...

    using UnityEngine;
    using System;
    using System.Collections.Generic;
    //using Microsoft.Research.Kinect.Nui;
 

    #endregion

    /// <summary>
    /// The gesture controler
    /// </summary>
    public class GestureControler : MonoBehaviour
    {
        /// <summary>
        /// The list of all gestures we are currently looking for
        /// </summary>
        private List<Gesture> gestures = new List<Gesture>();



        /// <summary>
        /// Initializes a new instance of the <see cref="GestureControler"/> class.
        /// </summary>
        public GestureControler()
        {
        }

        void Start()
        {
            DefineGesture();
        }
        void Update()
        {
            UpdateAllGestures();      
        }
 

        /// <summary>
        /// Occurs when [gesture recognised].
        /// </summary>
        //public event EventHandler<GestureEventArgs> GestureRecognised;

        /// <summary>
        /// Updates all gestures.
        /// </summary>
        /// <param name="data">The skeleton data.</param>
        public void UpdateAllGestures()
        {
            foreach (Gesture gesture in this.gestures)
            {
                gesture.UpdateGesture(SkeletonInformation.skeletonWrapper);
            }
        }


        /// <summary>
        /// Adds the gesture.
        /// </summary>
        /// <param name="type">The gesture type.</param>
        /// <param name="gestureDefinition">The gesture definition.</param>
        public void AddGesture(GestureType type, IRelativeGestureSegment[] gestureDefinition)
        {
            Gesture gesture = new Gesture(type, gestureDefinition);
           // gesture.GestureRecognised += new EventHandler<GestureEventArgs>(this.Gesture_GestureRecognised);
            this.gestures.Add(gesture);
        }

        /*
        /// <summary>
        /// Handles the GestureRecognised event of the g control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KinectSkeltonTracker.GestureEventArgs"/> instance containing the event data.</param>
        private void Gesture_GestureRecognised(object sender, GestureEventArgs e)
        {
            if (this.GestureRecognised != null)
            {
                this.GestureRecognised(this, e);
            }

            foreach (Gesture g in this.gestures)
            {
                g.Reset();
            }
        }
         */

        public void DefineGesture()
        {
            /*
            IRelativeGestureSegment[] waveRightSegments = new IRelativeGestureSegment[6];
            WaveRightSegment1 waveRightSegment1 = new WaveRightSegment1();
            WaveRightSegment2 waveRightSegment2 = new WaveRightSegment2();
            waveRightSegments[0] = waveRightSegment1;
            waveRightSegments[1] = waveRightSegment2;
            waveRightSegments[2] = waveRightSegment1;
            waveRightSegments[3] = waveRightSegment2;
            waveRightSegments[4] = waveRightSegment1;
            waveRightSegments[5] = waveRightSegment2;
            this.gestures.AddGesture(GestureType.WaveRight, waveRightSegments);
            
            IRelativeGestureSegment[] waveLeftSegments = new IRelativeGestureSegment[6];
            WaveLeftSegment1 waveLeftSegment1 = new WaveLeftSegment1();
            WaveLeftSegment2 waveLeftSegment2 = new WaveLeftSegment2();
            waveLeftSegments[0] = waveLeftSegment1;
            waveLeftSegments[1] = waveLeftSegment2;
            waveLeftSegments[2] = waveLeftSegment1;
            waveLeftSegments[3] = waveLeftSegment2;
            waveLeftSegments[4] = waveLeftSegment1;
            waveLeftSegments[5] = waveLeftSegment2;
            this.gestures.AddGesture(GestureType.WaveLeft, waveLeftSegments);
            */
            IRelativeGestureSegment[] swipeleftSegments = new IRelativeGestureSegment[3];
            swipeleftSegments[0] = new SwipeLeftSegment1();
            swipeleftSegments[1] = new SwipeLeftSegment2();
            swipeleftSegments[2] = new SwipeLeftSegment3();
            this.AddGesture(GestureType.LeftSwipe, swipeleftSegments);
            /*
            IRelativeGestureSegment[] swiperightSegments = new IRelativeGestureSegment[3];
            swiperightSegments[0] = new SwipeRightSegment1();
            swiperightSegments[1] = new SwipeRightSegment2();
            swiperightSegments[2] = new SwipeRightSegment3();
            this.gestures.AddGesture(GestureType.RightSwipe, swiperightSegments);

            IRelativeGestureSegment[] menuSegments = new IRelativeGestureSegment[20];
            MenuSegments1 menuSegment = new MenuSegments1();
            for (int i = 0; i < 20; i++)
            {
                // gesture consists of the same thing 20 times 
                menuSegments[i] = menuSegment;
            }

            this.gestures.AddGesture(GestureType.Menu, menuSegments);
            */
        }
    }
//}
