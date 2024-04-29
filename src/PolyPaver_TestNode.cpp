//
// Created by brandon on 4/29/24.
//

#include "PolyPaver_TestNode.h"
#include <godot_cpp/core/class_db.hpp>

using namespace godot;

void PolyPaver_TestNode::_bind_methods()
{
    ClassDB::bind_method(D_METHOD("get_speed"), &PolyPaver_TestNode::get_speed);
    ClassDB::bind_method(D_METHOD("set_speed", "p_speed"), &PolyPaver_TestNode::set_speed);
    ClassDB::add_property("PolyPaver_TestNode", PropertyInfo(Variant::FLOAT, "speed", PROPERTY_HINT_RANGE, "0,20,0.01"), "set_speed", "get_speed");

}

PolyPaver_TestNode::PolyPaver_TestNode() {
    time_passed = 0.0;
    speed = 1.0;
}

PolyPaver_TestNode::~PolyPaver_TestNode() = default;

void PolyPaver_TestNode::_process(double delta)
{
    time_passed += delta;
    Vector3 new_position = Vector3(10.0 + (10.0 * sin(time_passed * speed)), 10.0 + (10.0 * cos(time_passed * speed)), 10.0 + (10.0 * sin(time_passed * speed)));

    set_position(new_position);
}

void PolyPaver_TestNode::set_speed(const double p_speed) {
    speed = p_speed;

}

double PolyPaver_TestNode::get_speed() const {
    return speed;
}
