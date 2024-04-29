//
// Created by brandon on 4/29/24.
//

#ifndef POLYPAVER_POLYPAVER_TESTNODE_H
#define POLYPAVER_POLYPAVER_TESTNODE_H
#include <godot_cpp/classes/node3d.hpp>

using namespace godot;

class PolyPaver_TestNode : public Node3D {
    GDCLASS(PolyPaver_TestNode, Node3D)

private:
    double time_passed;
    double speed;
protected:
    static void _bind_methods();
public:
    void set_speed(const double p_speed);
    double get_speed() const;
    PolyPaver_TestNode();
    ~PolyPaver_TestNode();

    void _process(double delta) override;


};


#endif //POLYPAVER_POLYPAVER_TESTNODE_H
