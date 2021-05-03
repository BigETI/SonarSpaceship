# Game design

## Overview

"Sonar Spaceship" (working title) is a game about a spaceship navigating through dangerous and dark space, while using its electro-magnetic sonar system, which in short is called EMSS. Your goal is to collect containers of unknown origin for your scientific team to study its contents.

The EMSS can be used to detect obstacles, which reflect those waves to produce audio feedback. You can only shoot EM waves at specified directions.

Your spaceship has a limited amount of fuel, so you have to rely on re-fueling stations that may contain limited amount of re-fills.

## Entities

### Spaceship

You are the captain of this ship, and have to navigate through dangerous space.

### Research module

The research module is part of the mothership, and is the point where our spaceship gets dropped off to collect those containers and bring back to the module.

### Rocks

They can obstruct your path, but do not deal that much damage, if you are careful.

### Mines

Once your spaceship touches one of them, then it is a guaranteed game over for you.

### Container of unknown origin

They are strangely shaped containers, most likely alien origin, your scientific team wants to study its contents. Your spaceship is able to grab one and take it back to the research module. There could be multiple of them inside a single area. Your goal is to collect all of them.

# Game mechanics

Your spaceship can move on a 2D plane to any direction.
The speed of the spaceship can't exceed a given limit.
Inertia dampeners are used to slow down your spaceship, however heavy cargo makes this harder.
Your spaceship is able to pick up one container at a time.
There can be many containers floating around in their close proximities.
Your electro-magnetic sonar system (EMSS) can be used infinitely, however each use takes a bit of fuel. EMMS can only spread EM waves 20° in front of your spaceship with a limited distance. An EM wave has a speed limit, so you can hear or see a delay in your radar.

# Controls

## PC/Mac

- WASD or gamepad left stick to move
- Mouse movement or gamepad right stick to aim
- Left mouse button or gamepad left stick button to ping

## Mobile

- Pressing or gamepad left stick to move
- Pressing or gamepad right stick to aim
- Virtual ping button or gamepad left stick button to ping

# Requirements

- Support for OpenGL ES 2.x to 3.x, Vulkan or Metal
- Mouse and keyboard, gamepad or touch screen
- Headphones for audio navigation
