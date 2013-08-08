// -----------------------------------------------------------------------
// <copyright file="SwipeLeftSegment2.cs" company="Microsoft Limited">
//  Copyright (c) Microsoft Limited, Microsoft Consulting Services, UK. All rights reserved.
// All rights reserved.
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>The second part of the swipe left gesture</summary>
//-----------------------------------------------------------------------
//namespace KinectSkeltonTracker.Gestures.GestureParts
//{
    #region using...

    using UnityEngine;
    //using Microsoft.Research.Kinect.Nui;

    #endregion

    /// <summary>
    /// The second part of the swipe left gesture
    /// </summary>
    public class SwipeLeftSegment2 : IRelativeGestureSegment
    {
        /// <summary>
        /// Checks the gesture.
        /// </summary>
        /// <param name="skeleton">The skeleton.</param>
        /// <returns>GesturePartResult based on if the gesture part has been completed</returns>
        public GesturePartResult CheckGesture(SkeletonWrapper skeletonWrapper)
        {
            // //Right hand in front of right shoulder
            if (skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HandRight].z > skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.ElbowRight].z)
                //skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HandLeft].y < skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HipCenter].y)
            {
                // Debug.WriteLine("GesturePart 1 - Right hand in front of right shoulder - PASS");
                // //right hand below shoulder height but above hip height
                if (skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HandRight].y < skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.Head].y &&
                    skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HandRight].y > skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HipCenter].y)
                {
                    // Debug.WriteLine("GesturePart 1 - right hand below shoulder height but above hip height - PASS");
                    // //right hand left of right shoulder & right of left shoulder
                    if (skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HandRight].x < skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.ShoulderRight].x) //&&
                        //skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HandRight].x > skeletonWrapper.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.ShoulderLeft].x)
                    {
                        // Debug.WriteLine("GesturePart 1 - right hand left of right shoulder & right of left shoulder - PASS");
                        return GesturePartResult.Suceed;
                    }

                    // Debug.WriteLine("GesturePart 1 - right hand left of right shoulder & right of left shoulder - UNDETERMINED");
                    return GesturePartResult.Pausing;
                }

                // Debug.WriteLine("GesturePart 1 - right hand below shoulder height but above hip height - FAIL");
                return GesturePartResult.Fail;
            }

            // Debug.WriteLine("GesturePart 1 - Right hand in front of right shoulder - FAIL");
            return GesturePartResult.Fail;
        }
    }
//}