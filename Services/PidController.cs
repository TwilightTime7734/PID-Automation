using System;

namespace DronePidTuningAssistant.WinForms.Services;

public sealed class PidController
{
    private double _integral;
    private double _previousError;
    private bool _hasPrevious;

    public double Kp { get; set; }
    public double Ki { get; set; }
    public double Kd { get; set; }
    public double OutputMin { get; set; } = double.NegativeInfinity;
    public double OutputMax { get; set; } = double.PositiveInfinity;

    public PidController(double kp = 0, double ki = 0, double kd = 0)
    {
        Kp = kp;
        Ki = ki;
        Kd = kd;
    }

    public void Reset()
    {
        _integral = 0.0;
        _previousError = 0.0;
        _hasPrevious = false;
    }

    // error = setpoint - measurement
    public double Update(double error, double dtSeconds)
    {
        if (dtSeconds <= 0)
        {
            return 0.0;
        }

        // Proportional
        var p = Kp * error;

        // Integral
        _integral += error * dtSeconds;
        var i = Ki * _integral;

        // Derivative (on measurement via error derivative)
        double d = 0.0;
        if (_hasPrevious)
        {
            var derivative = (error - _previousError) / dtSeconds;
            d = Kd * derivative;
        }

        _previousError = error;
        _hasPrevious = true;

        var output = p + i + d;
        if (output > OutputMax) output = OutputMax;
        if (output < OutputMin) output = OutputMin;
        return output;
    }
}
