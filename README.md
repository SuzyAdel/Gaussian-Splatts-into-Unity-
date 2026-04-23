# Gaussian-Splatts-into-Unity-

Aim : turn a video streram of a drone into a world on unity with the least points , rather then point cloud and a lot of data processing 

What is Gaussian Splatt?



https://github.com/user-attachments/assets/6151d592-95f9-4596-a79b-274bd1fe4e91





<img width="603" height="232" alt="image" src="https://github.com/user-attachments/assets/9e2315d0-dc8c-4b06-a323-d2b3530a2a91" />



Steps to first extract the points of the raw video 
1. use 'ffmeg' to extract overlaping frames of the videos as images in a file 
<img width="1227" height="590" alt="image" src="https://github.com/user-attachments/assets/d2b2863a-e3e2-417b-bfc9-11ea9a790441" />

I wrote a command to trim the video to a few seconds whree the video is how=cering over the scene , and created images saved in a pre created folder 'img' 

- ffmpeg -i stonehenge.mp4 -ss 00:00:31 -to 00:06:03 -vf "fps=1,scale=iw:ih:flags=lanczos" -c:v mjpeg -q:v 2 -y ./img/frame_%05d.jpg


2. use 'RealityScan' to create poses
<img width="1918" height="1011" alt="image" src="https://github.com/user-attachments/assets/4b59e4bc-75a8-4320-acc7-1be4d6d079d4" />

 - ulter settings based on video , in this case
 - <img width="421" height="362" alt="image" src="https://github.com/user-attachments/assets/bc727191-0af6-43de-88b5-91e567f93d6b" />
 
 - try alignment and remove small (noise compartments) and repeat aligning , this improves quality
 - ulter settings again to orginal down sca;e and error reprojection 

<img width="421" height="422" alt="image" src="https://github.com/user-attachments/assets/af485a4f-8eda-43aa-bf2e-83a060be89e7" />

- export settings to colmap , as images with orginal namimg
- <img width="1919" height="1018" alt="image" src="https://github.com/user-attachments/assets/bddff2eb-14ef-4a35-9dda-840e2fd85d99" />

<img width="1146" height="922" alt="image" src="https://github.com/user-attachments/assets/29de3639-cf3b-4ecd-b5c7-6d47dec53241" />


3. start Brush to create Gaussian Splat Training
- Download from
- https://github.com/ArthurBrussee/brush/releases
  
Training Process: 




https://github.com/user-attachments/assets/ce0f6f73-c3c2-4517-9d16-d7d31d76b898


<img width="1919" height="1020" alt="image" src="https://github.com/user-attachments/assets/c3f0aa2a-b54f-4d6c-a876-7c75a91afbee" />

then export as ply , if we need to remove a bacground edit or clean we can use super splat but it is good enough to take from there and import on unity 

4. clone SPZ Unity Importer to import the .ply in unity
   
link: https://github.com/aras-p/UnityGaussianSplatting

<img width="1464" height="740" alt="image" src="https://github.com/user-attachments/assets/99a734e6-a2d7-47b4-96c3-044a3cf0e372" />
<img width="1007" height="321" alt="image" src="https://github.com/user-attachments/assets/b9e0cdf5-0678-4453-8574-3a8395d39184" />


5. pick HDRP to match the latest Unity
   
<img width="1857" height="820" alt="image" src="https://github.com/user-attachments/assets/be559b5c-fe69-4d5c-9d86-e57829e6f218" />

6. convert anything needed to match

<img width="1919" height="1027" alt="image" src="https://github.com/user-attachments/assets/62382ecc-6af9-478c-b987-551de4be42b1" />

7. Create Guassian Splatt asset

<img width="1919" height="977" alt="image" src="https://github.com/user-attachments/assets/cfd38df2-7c4c-42e5-90c6-42e0387450f0" />

8. drag and drop .ply and view it

Result: UNITY viewing .PlY:



https://github.com/user-attachments/assets/fa48bbb3-f3b5-40ad-94f3-7fcc5600c501


# Create a walkthrough view in Guassian Splatt

Cinemachine is built exactly for this "drone fly-through" or "architectural walkthrough" style.

🎥 Why Cinemachine is the Best Choice?

-- Virtual Camera System: You can set up "Waypoints" (spots) in your office and the camera will automatically glide between them with perfect math.

-- Dolly Tracks: This is the secret to that "Drone" look. You draw a path (a line) through your office, and the camera follows it like it's on a rail.

-- Noise (Handheld feel): You can add a "6D Shake" or "Drone Noise" to make the walkthrough feel like it was filmed by a real FPV drone.


9. first delete all extra cameras
<img width="1023" height="513" alt="image" src="https://github.com/user-attachments/assets/946acd8d-8135-4648-a770-63ebb7a11f44" />



10. Install Cinemachine in Unity

11. Cinemachine > Spline Dolly
<img width="1283" height="794" alt="image" src="https://github.com/user-attachments/assets/0e35908f-4105-427f-9520-ed4133890fd1" />


12. Add Spine and Knots

🛤️ What are we actually doing?

Think of this like a train track:

- The Spline: This is the entire "Track." It’s the invisible line that your camera will "ride" on.

- The Knots: These are the "Anchors" or "Stakes" in the ground. You place these Knots exactly where you want the drone to fly. Unity then draws a smooth, curved line (the Spline) between these Knots.


for a start try 3 knots then add the code to orbit and ulter 

Knot,X,Y (Height),Z

Knot [0],10.0,3.5,0.0

Knot [1],−5.0,3.5,8.6

Knot [2],−5.0,3.5,−8.6


Trial 1:

https://github.com/user-attachments/assets/eb90abc3-7b02-4e0a-92cb-46da20f89c97


- to be able to track which knott and test correctly i created a script to track so, and be able to ulter manually where the issue is as the guasian point has a slight angle
- i also needed more knots to create a 360 like angle glide around it 

Trial 2: 

Knot,X,Y (Adjusted Height),Z

Knot [0],20.0,10.0,0.0

Knot [1],14.1,12.5,14.1

Knot [2],0.0,15.0,20.0

Knot [3],−14.1,16.5,14.1

Knot [4],−20.0,18.0,0.0

Knot [5],−14.1,16.5,−14.1

Knot [6],0.0,14.0,−20.0

Knot [7],14.1,11.5,−14.1


https://github.com/user-attachments/assets/f4c8e881-8811-407d-b1d1-603d36124fc8

# Creating a First Person view

13. added a simple move script to the CameraTarget
14. inserted a normal cenimamachine and set target to the CameraTarget (empty object)

<img width="633" height="773" alt="image" src="https://github.com/user-attachments/assets/f001d251-a7d8-482f-b896-f85cd1f37b48" />

   
15. then edited the damping and the offset values
16. due to the speed prefrences i added a float public value to control

RESULTS :


https://github.com/user-attachments/assets/0294aad7-b8e1-4a41-a01a-5b6305b20902


https://github.com/user-attachments/assets/9bcb7cee-3c60-4dac-85ea-b4dc4ba96aa1


this can be used or switched to , however there is no option to rotate 

# Create 3RD View Camera 

17. inserted a FreeLook Camera 
<img width="1919" height="895" alt="image" src="https://github.com/user-attachments/assets/b11a3ac5-99e8-4a13-9eba-86bfd0d875fd" />

18. Update the settings to suit the projects need


THought Process :

- Tracking Target (Follow): This is the path the camera sits on; it moves the camera's physical body through the 3D space.

-- The "Empty Object" (Follow)

- Look At: This is the focal point the camera's lens is locked onto; it rotates the camera's "head" to keep the object centered.
  
-- "Look At" (Mouse/Cursor View)

however, in free look it already makes the mouse look and control along with following the target 
we then just need to fix the orbits to give 3 or more pov and there is a built in spine to move along them 


19. ultering the 3 default orbits:
    
<img width="1687" height="664" alt="image" src="https://github.com/user-attachments/assets/b612b949-d171-4b02-8ae0-492d30629566" />
 this has 3 POV and moves along them 

Results :




https://github.com/user-attachments/assets/597d8fd8-04aa-4667-9f1b-518f8f7aa5bb





20. ultering and tring sphere radius


<img width="1704" height="896" alt="image" src="https://github.com/user-attachments/assets/42add87f-2512-4f18-9667-acbe96a1a11a" />



https://github.com/user-attachments/assets/17643fb9-bd36-4b72-a895-c64a025a2c6c





# Comparson betwween cameras 

1. The 8-Knot Spline (Manual)

As  noted, this was "very easy to quickly spin" once set up. By placing 8 knots, you created a high-fidelity track that guaranteed the camera wouldn't "wobble". For your Digital Twin, this is the "Auto-Pilot" mode where the viewer just sits back and watches the highlights.

2. First Person (Linear/Servo)

 Identifed that this is great for "close-ups" but lacks rotation. In your university project, you will likely use this when the user wants to walk up to a specific piece of equipment to check a "Digital Twin" data point.

3. The 3-Orbit Free Look

This gave  the "most flexibility" because it combined manual movement with fixed levels. It solves the "slouching" issue by allowing the user to jump to a "Top View" if the camera is getting too close to the grass.

4. The Radius Sphere

This is the "fullest coverage" method. By using a sphere, it removed the limitations of a 2D track. It allows the camera to rotate on all axes, which is ideal for inspecting a complex, non-linear object like Stonehenge or a piece of machinery from every possible angle.


# Trial To Use Camera Position output to create a Dolly Cinemamachine 

<img width="764" height="268" alt="image" src="https://github.com/user-attachments/assets/d08ecb07-74e9-410a-bc14-093df985051e" />

21. first trial i created knots every frame , and this createded a large messy and noisey train , however our current goal is to alternate between quick view and walk through so we need to reduce to 20-30 knots max

<img width="1919" height="708" alt="image" src="https://github.com/user-attachments/assets/1dd3763b-2049-4d35-9e99-8d65620b8ede" />

22. found issues of the calulations outputs and scale issues 

<img width="1919" height="950" alt="image" src="https://github.com/user-attachments/assets/ff4ffec6-5b02-47bf-8c5f-4d8419789295" />

23. fixed but wrong orentation , got to skip 30 frames enough to cover paths , fixed scale

<img width="1919" height="742" alt="image" src="https://github.com/user-attachments/assets/1b6804a3-0093-41e4-8160-764f8484dd8f" />

24. ultered the look at and follow on a emty target to look at and rotate on a certain point of view



https://github.com/user-attachments/assets/4f2b1121-283d-4da4-8902-ff3cf2509109


