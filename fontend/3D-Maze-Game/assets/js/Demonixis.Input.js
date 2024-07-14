/** @namespace */
var Demonixis = Demonixis || {};

Demonixis.Input = function() {
    this.keys = {
        up: false,
        down: false,
        left: false,
        right: false,
        space: false,
        enter: false,
        control: false,
        alt: false,
        shift: false,
        backspace: false, // Added backspace
        num_0: false,
        num_1: false,
        num_2: false,
        num_3: false,
        num_4: false,
        num_5: false,
        num_6: false,
        num_7: false,
        num_8: false,
        num_9: false,
        a: false,
        b: false,
        c: false,
        d: false,
        e: false,
        f: false,
        g: false,
        h: false,
        i: false,
        j: false,
        k: false,
        l: false,
        m: false,
        n: false,
        o: false,
        p: false,
        q: false,
        r: false,
        s: false,
        t: false,
        u: false,
        v: false,
        w: false,
        x: false,
        y: false,
        z: false,
        k_0: false,
        k_1: false,
        k_2: false,
        k_3: false,
        k_4: false,
        k_5: false,
        k_6: false,
        k_7: false,
        k_8: false,
        k_9: false
    };

    this.keyboardState = {
        current: null,
        last: null
    };

    this.joykeys = {
        up: false,
        down: false,
        left: false,
        right: false,
        upLeft: false,
        upRight: false,
        downLeft: false,
        downRight: false,
        actionA: false,
        actionB: false,
        actionC: false,
        actionX: false,
        actionY: false,
        actionZ: false,
        triggerL: false,
        triggerR: false,
        start: false,
        select: false
    };

    this.joykeyState = {
        current: null,
        last: null
    };

    var _this = this;

    // Clavier
    this._onKeyboardDown = function(event) {
        _this._onKeyStateChange(event, true);
    };

    this._onKeyboardUp = function(event) {
        _this._onKeyStateChange(event, false);
    };

    document.addEventListener('keydown', this._onKeyboardDown, false);
    document.addEventListener('keyup', this._onKeyboardUp, false);

    // Joystick virtuel
    this.virtualJoyKeys = document.getElementsByClassName("joykey");

    this._onJoykeyDown = function(event) {
        _this._onJoykeyStateChange(event, true);
    };

    this._onJoykeyUp = function(event) {
        _this._onJoykeyStateChange(event, false);
    };

    for (var i = 0, l = this.virtualJoyKeys.length; i < l; i++) {
        this.virtualJoyKeys[i].addEventListener("mousedown", this._onJoykeyDown, false);
        this.virtualJoyKeys[i].addEventListener("mouseup", this._onJoykeyUp, false);
        this.virtualJoyKeys[i].addEventListener("touchstart", this._onJoykeyDown, false);
        this.virtualJoyKeys[i].addEventListener("touchend", this._onJoykeyUp, false);
    }
};

Demonixis.Input.prototype.destroy = function() {
    document.removeEventListener('keydown', this._onKeyboardDown, false);
    document.removeEventListener('keyup', this._onKeyboardUp, false);

    for (var i = 0, l = this.virtualJoyKeys.length; i < l; i++) {
        this.virtualJoyKeys[i].removeEventListener("mousedown", this._onJoykeyDown, false);
        this.virtualJoyKeys[i].removeEventListener("mouseup", this._onJoykeyUp, false);
        this.virtualJoyKeys[i].removeEventListener("touchstart", this._onJoykeyDown, false);
        this.virtualJoyKeys[i].removeEventListener("touchend", this._onJoykeyUp, false);
    }
};

Demonixis.Input.prototype._onKeyStateChange = function(event, pressed) {
    if (event.ctrlKey && (event.key === 'c' || event.key === 'v')) {
        return;
    }

    event.preventDefault();

    switch (event.keyCode) {
        case 8:
            this.keys.backspace = pressed;
            break; // Backspace
        case 13:
            this.keys.enter = pressed;
            break; // Enter
        case 16:
            this.keys.shift = pressed;
            break; // Shift    
        case 17:
            this.keys.control = pressed;
            break; // Control
        case 18:
            this.keys.alt = pressed;
            break; // Alt                        
        case 32:
            this.keys.space = pressed;
            break; // Space
        case 37:
            this.keys.left = pressed;
            break; // Left
        case 38:
            this.keys.up = pressed;
            break; // Up
        case 39:
            this.keys.right = pressed;
            break; // Right
        case 40:
            this.keys.down = pressed;
            break; // Down
        case 48:
            this.keys.k_0 = pressed;
            break; // Key 0
        case 49:
            this.keys.k_1 = pressed;
            break; // Key 1
        case 50:
            this.keys.k_2 = pressed;
            break; // Key 2
        case 51:
            this.keys.k_3 = pressed;
            break; // Key 3
        case 52:
            this.keys.k_4 = pressed;
            break; // Key 4
        case 53:
            this.keys.k_5 = pressed;
            break; // Key 5
        case 54:
            this.keys.k_6 = pressed;
            break; // Key 6
        case 55:
            this.keys.k_7 = pressed;
            break; // Key 7
        case 56:
            this.keys.k_8 = pressed;
            break; // Key 8
        case 57:
            this.keys.k_9 = pressed;
            break; // Key 9
        case 65:
            this.keys.a = pressed;
            break; // Key A
        case 66:
            this.keys.b = pressed;
            break; // Key B
        case 67:
            this.keys.c = pressed;
            break; // Key C
        case 68:
            this.keys.d = pressed;
            break; // Key D
        case 69:
            this.keys.e = pressed;
            break; // Key E
        case 70:
            this.keys.f = pressed;
            break; // Key F
        case 71:
            this.keys.g = pressed;
            break; // Key G
        case 72:
            this.keys.h = pressed;
            break; // Key H
        case 73:
            this.keys.i = pressed;
            break; // Key I
        case 74:
            this.keys.j = pressed;
            break; // Key J
        case 75:
            this.keys.k = pressed;
            break; // Key K
        case 76:
            this.keys.l = pressed;
            break; // Key L
        case 77:
            this.keys.m = pressed;
            break; // Key M
        case 78:
            this.keys.n = pressed;
            break; // Key N
        case 79:
            this.keys.o = pressed;
            break; // Key O
        case 80:
            this.keys.p = pressed;
            break; // Key P
        case 81:
            this.keys.q = pressed;
            break; // Key Q
        case 82:
            this.keys.r = pressed;
            break; // Key R
        case 83:
            this.keys.s = pressed;
            break; // Key S
        case 84:
            this.keys.t = pressed;
            break; // Key T
        case 85:
            this.keys.u = pressed;
            break; // Key U
        case 86:
            this.keys.v = pressed;
            break; // Key V
        case 87:
            this.keys.w = pressed;
            break; // Key W
        case 88:
            this.keys.x = pressed;
            break; // Key X
        case 89:
            this.keys.y = pressed;
            break; // Key Y
        case 90:
            this.keys.z = pressed;
            break; // Key Z
        case 96:
            this.keys.num_0 = pressed;
            break; // Numpad 0
        case 97:
            this.keys.num_1 = pressed;
            break; // Numpad 1 
        case 98:
            this.keys.num_2 = pressed;
            break; // Numpad 2
        case 99:
            this.keys.num_3 = pressed;
            break; // Numpad 3
        case 100:
            this.keys.num_4 = pressed;
            break; // Numpad 4
        case 101:
            this.keys.num_5 = pressed;
            break; // Numpad 5
        case 102:
            this.keys.num_6 = pressed;
            break; // Numpad 6
        case 103:
            this.keys.num_7 = pressed;
            break; // Numpad 7
        case 104:
            this.keys.num_8 = pressed;
            break; // Numpad 8
        case 105:
            this.keys.num_9 = pressed;
            break; // Numpad 9
    }
};

Demonixis.Input.prototype._onJoykeyStateChange = function(event, pressed) {
    event.preventDefault();
    var id = event.currentTarget.id;

    switch (id) {
        case "keyup":
            this.joykeys.up = pressed;
            break;
        case "keydown":
            this.joykeys.down = pressed;
            break;
        case "keyleft":
            this.joykeys.left = pressed;
            break;
        case "keyright":
            this.joykeys.right = pressed;
            break;

        case "keyUpLeft":
            this.joykeys.upLeft = pressed;
            break;
        case "keyUpRight":
            this.joykeys.upRight = pressed;
            break;
        case "keyDownLeft":
            this.joykeys.downLeft = pressed;
            break;
        case "keyDownRight":
            this.joykeys.downRight = pressed;
            break;

        case "keyActionA":
            this.joykeys.actionA = pressed; // Changed to actionA
            break;
        case "keyActionB":
            this.joykeys.actionB = pressed; // Changed to actionB
            break;
        case "keyActionC":
            this.joykeys.actionC = pressed; // Changed to actionC
            break;
        case "keyActionX":
            this.joykeys.actionX = pressed; // Changed to actionX
            break;
        case "keyActionY":
            this.joykeys.actionY = pressed; // Changed to actionY
            break;
        case "keyActionZ":
            this.joykeys.actionZ = pressed; // Changed to actionZ
            break;

        case "keyTriggerL":
            this.joykeys.triggerL = pressed;
            break;
        case "keyTriggerR":
            this.joykeys.triggerR = pressed;
            break;

        case "keyButtonStart":
            this.joykeys.start = pressed;
            break;
        case "keyButtonSelect":
            this.joykeys.select = pressed;
            break;
    }
};

Demonixis.Input.prototype.pressed = function(key) {
    return this.keys[key];
};
