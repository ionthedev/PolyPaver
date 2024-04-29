cmake_minimum_required(VERSION 3.28)
project(PolyPaver)

set(CMAKE_CXX_STANDARD 17)

include_directories(godot-cpp/gdextension)
include_directories(godot-cpp/gen/include)
include_directories(godot-cpp/gen/include/godot_cpp)
include_directories(godot-cpp/gen/include/godot_cpp/classes)
include_directories(godot-cpp/gen/include/godot_cpp/core)
include_directories(godot-cpp/gen/include/godot_cpp/variant)
include_directories(godot-cpp/include)
include_directories(godot-cpp/include/godot_cpp)
include_directories(godot-cpp/include/godot_cpp/classes)
include_directories(godot-cpp/include/godot_cpp/core)
include_directories(godot-cpp/include/godot_cpp/templates)
include_directories(godot-cpp/include/godot_cpp/variant)
include_directories(godot-cpp/test/src)
include_directories(src)

add_executable(PolyPaver
        src/register_types.h
        src/register_types.cpp
        src/PolyPaver_TestNode.h
        src/PolyPaver_TestNode.cpp)
