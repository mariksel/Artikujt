<?php
class ApiResponse{
    public $model;
    public bool $succeeded;
    public string $message;

    public function __construct($model, bool $succeeded, string $message)
    {
        $this->model = $model;
        $this->succeeded = $succeeded;
        $this->message = $message;
    }
}