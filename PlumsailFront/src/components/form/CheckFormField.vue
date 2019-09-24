<template>
    <div>
        <label class="form-title">{{label}}</label>
        <div>
            <slot />
        </div>
        <span class="form-error-text">{{error}}</span>
    </div>
</template>

<script>
export default {
    props: {
        label: {
            type: String,
            required: true
        },
        error: String,
    },
}
</script>